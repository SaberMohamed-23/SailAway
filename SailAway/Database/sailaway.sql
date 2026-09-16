
/*
    Project: SailAway Botenverhuur
    Database: MySQL / MariaDB via XAMPP

    Deze database is afgestemd op de SailAway-usecases:
    - klanten registreren/inloggen en eigen gegevens beheren
    - klanten zoeken op achternaam, telefoonnummer en e-mail
    - boten beheren en koppelen aan bootsoort + locatie
    - per locatie bepalen welke bootsoorten worden aangeboden
    - boten filteren op locatie, type en capaciteit
    - reserveringen maken/wijzigen/annuleren met datum en tijd
    - dubbele reserveringen van dezelfde boot voorkomen
*/

DROP DATABASE IF EXISTS sailaway;

CREATE DATABASE sailaway
CHARACTER SET utf8mb4
COLLATE utf8mb4_general_ci;

USE sailaway;

-- =========================================================
-- 1. TABELLEN
-- =========================================================

CREATE TABLE gebruikers
(
    gebruiker_id INT NOT NULL AUTO_INCREMENT,
    email VARCHAR(255) NOT NULL,
    wachtwoord VARCHAR(255) NOT NULL,
    rol ENUM('Klant','Medewerker','Beheerder','Leidinggevende') NOT NULL DEFAULT 'Klant',
    actief BOOLEAN NOT NULL DEFAULT TRUE,

    CONSTRAINT PK_gebruikers PRIMARY KEY (gebruiker_id),
    CONSTRAINT AK_gebruikers_email UNIQUE (email)
);

CREATE TABLE klanten
(
    klant_id INT NOT NULL AUTO_INCREMENT,
    gebruiker_id INT NULL,
    voornaam VARCHAR(100) NOT NULL,
    tussenvoegsel VARCHAR(30) NULL,
    achternaam VARCHAR(100) NOT NULL,
    geboortedatum DATE NOT NULL,
    telefoonnummer VARCHAR(30) NOT NULL,
    email VARCHAR(255) NOT NULL,

    CONSTRAINT PK_klanten PRIMARY KEY (klant_id),
    CONSTRAINT AK_klanten_email UNIQUE (email),
    CONSTRAINT FK_klanten_gebruikers
        FOREIGN KEY (gebruiker_id) REFERENCES gebruikers(gebruiker_id)
        ON DELETE SET NULL
);

CREATE TABLE bootsoorten
(
    bootsoort_id INT NOT NULL AUTO_INCREMENT,
    naam VARCHAR(100) NOT NULL,
    beschrijving VARCHAR(500) NOT NULL,

    CONSTRAINT PK_bootsoorten PRIMARY KEY (bootsoort_id),
    CONSTRAINT AK_bootsoorten_naam UNIQUE (naam)
);

CREATE TABLE locaties
(
    locatie_id INT NOT NULL AUTO_INCREMENT,
    naam VARCHAR(150) NOT NULL,
    adres VARCHAR(255) NOT NULL,
    beschrijving VARCHAR(500) NOT NULL,

    CONSTRAINT PK_locaties PRIMARY KEY (locatie_id),
    CONSTRAINT AK_locaties_naam UNIQUE (naam)
);



CREATE TABLE boten (
    boot_id INT NOT NULL AUTO_INCREMENT,
    naam VARCHAR(100) NOT NULL,
    merk VARCHAR(100) NOT NULL,
    bootsoort_id INT NOT NULL,
    capaciteit INT NOT NULL,
    bouwjaar INT NOT NULL,
    lengte DECIMAL(6,2) NOT NULL,
    omschrijving VARCHAR(1000) NOT NULL,
    prijs_per_uur DECIMAL(10,2) NOT NULL,
    locatie_id INT NOT NULL,

    CONSTRAINT PK_boten PRIMARY KEY (boot_id),

    CONSTRAINT FK_boten_bootsoort
        FOREIGN KEY (bootsoort_id)
        REFERENCES bootsoorten(bootsoort_id),

    CONSTRAINT FK_boten_locatie
        FOREIGN KEY (locatie_id)
        REFERENCES locaties(locatie_id),

    CONSTRAINT CK_boten_capaciteit
        CHECK (capaciteit > 0),

    CONSTRAINT CK_boten_bouwjaar
        CHECK (bouwjaar BETWEEN 1900 AND 2100),

    CONSTRAINT CK_boten_lengte
        CHECK (lengte > 0),

    CONSTRAINT CK_boten_prijs
        CHECK (prijs_per_uur >= 0)
);

CREATE TABLE reserveringen
(
    reservering_id INT NOT NULL AUTO_INCREMENT,
    klant_id INT NOT NULL,
    boot_id INT NOT NULL,
    datum DATE NOT NULL,
    begintijd TIME NOT NULL,
    eindtijd TIME NOT NULL,
    aantal_personen INT NOT NULL,
    status ENUM('Actief', 'Geannuleerd', 'Voltooid') NOT NULL DEFAULT 'Actief',

    CONSTRAINT PK_reserveringen PRIMARY KEY (reservering_id),

    CONSTRAINT FK_reserveringen_klanten
        FOREIGN KEY (klant_id) REFERENCES klanten(klant_id)
        ON DELETE CASCADE,

    CONSTRAINT FK_reserveringen_boot
        FOREIGN KEY (boot_id) REFERENCES boten(boot_id),

    CONSTRAINT CK_reserveringen_personen CHECK (aantal_personen > 0),
    CONSTRAINT CK_reserveringen_tijd CHECK (eindtijd > begintijd)
);

-- =========================================================
-- 2. INDEXEN VOOR DE USECASES
-- =========================================================

-- Klanten moeten gezocht kunnen worden op deze velden.
CREATE INDEX IX_klanten_achternaam ON klanten(achternaam);
CREATE INDEX IX_klanten_telefoonnummer ON klanten(telefoonnummer);

-- Boten worden gefilterd op locatie, type en aantal personen/capaciteit.
CREATE INDEX IX_boten_filter ON boten(locatie_id, bootsoort_id, capaciteit);

-- Voor gekoppelde reserveringen en beschikbaarheidscontrole.
CREATE INDEX IX_reserveringen_klant ON reserveringen(klant_id);
CREATE INDEX IX_reserveringen_beschikbaarheid
    ON reserveringen(boot_id, datum, begintijd, eindtijd, status);

-- =========================================================
-- 3. CONTROLE OP DUBBELE RESERVERINGEN EN CAPACITEIT
-- =========================================================

DELIMITER $$

CREATE TRIGGER TR_reserveringen_before_insert
BEFORE INSERT ON reserveringen
FOR EACH ROW
BEGIN
    DECLARE boot_capaciteit INT;

    SELECT capaciteit
    INTO boot_capaciteit
    FROM boten
    WHERE boot_id = NEW.boot_id;

    IF NEW.aantal_personen > boot_capaciteit THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Aantal personen is hoger dan de capaciteit van de boot.';
    END IF;

    IF NEW.status <> 'Geannuleerd' AND EXISTS
    (
        SELECT 1
        FROM reserveringen r
        WHERE r.boot_id = NEW.boot_id
          AND r.datum = NEW.datum
          AND r.status <> 'Geannuleerd'
          AND NEW.begintijd < r.eindtijd
          AND NEW.eindtijd > r.begintijd
    ) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Deze boot is op dit tijdstip al gereserveerd.';
    END IF;
END$$

CREATE TRIGGER TR_reserveringen_before_update
BEFORE UPDATE ON reserveringen
FOR EACH ROW
BEGIN
    DECLARE boot_capaciteit INT;

    SELECT capaciteit
    INTO boot_capaciteit
    FROM boten
    WHERE boot_id = NEW.boot_id;

    IF NEW.aantal_personen > boot_capaciteit THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Aantal personen is hoger dan de capaciteit van de boot.';
    END IF;

    IF NEW.status <> 'Geannuleerd' AND EXISTS
    (
        SELECT 1
        FROM reserveringen r
        WHERE r.boot_id = NEW.boot_id
          AND r.datum = NEW.datum
          AND r.reservering_id <> NEW.reservering_id
          AND r.status <> 'Geannuleerd'
          AND NEW.begintijd < r.eindtijd
          AND NEW.eindtijd > r.begintijd
    ) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Deze boot is op dit tijdstip al gereserveerd.';
    END IF;
END$$

DELIMITER ;

-- =========================================================
-- 4. TESTDATA
-- =========================================================

INSERT INTO bootsoorten (bootsoort_id, naam, beschrijving) VALUES
(1, 'Motorboot', 'Boot met motor voor recreatief varen.'),
(2, 'Zeilboot', 'Boot die voornamelijk met zeilen wordt voortbewogen.'),
(3, 'Kano', 'Kleine boot die met een peddel wordt voortbewogen.');

INSERT INTO locaties (locatie_id, naam, adres, beschrijving) VALUES
(1, 'Sail Away ''s-Hertogenbosch', 'Botenboulevard 3, ''s-Hertogenbosch', 'Startlocatie in ''s-Hertogenbosch.'),
(2, 'Sail Away Oss', 'Oss', 'Startlocatie in Oss.'),
(3, 'Sail Away Veghel', 'Veghel', 'Startlocatie in Veghel.');

-- (removed locatie_bootsoorten mapping table; availability derived from boten table)

INSERT INTO boten
(boot_id, naam, merk, bootsoort_id, capaciteit, bouwjaar, lengte, omschrijving, prijs_per_uur, locatie_id)
VALUES
(1, 'Sea Star', 'Yamaha', 1, 6, 2021, 7.50, 'Comfortabele motorboot voor een dag op het water.', 60.00, 3),
(2, 'Blue Wave', 'Jeanneau', 2, 4, 2020, 6.80, 'Zeilboot voor recreatief varen.', 45.00, 1),
(3, 'River One', 'Wilderness', 3, 2, 2022, 4.20, 'Kano voor twee personen.', 20.00, 2);

-- Eenvoudige testgebruiker en bijbehorende klant om reserveringen te kunnen testen.
INSERT INTO gebruikers (gebruiker_id, email, wachtwoord, rol, actief) VALUES
(1, 'test@sailaway.nl', 'test123', 'Klant', true);

INSERT INTO klanten
(klant_id, gebruiker_id, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email)
VALUES
(1, 1, 'Test', NULL, 'Klant', '2000-01-01', '0612345678', 'test@sailaway.nl');

-- Voorbeeldreservering. Deze kan later via de applicatie worden verwijderd.
-- Single reservation example (location derived from boot)
INSERT INTO reserveringen
 (reservering_id, klant_id, boot_id, datum, begintijd, eindtijd, aantal_personen, status)
VALUES
 (1, 1, 1, '2026-10-01', '10:00:00', '12:00:00', 4, 'Actief');

-- =========================================================
-- TESTDATA / DUMMY DATA
-- Clear and beginner-friendly examples using fixed IDs
-- =========================================================

-- Additional gebruikers (users) - total 8 users (including existing test user id 1)
INSERT INTO gebruikers (gebruiker_id, email, wachtwoord, rol, actief) VALUES
(2, 'anna.klein@example.com', 'pass456', 'Klant', true),
(3, 'medewerk.jan@example.com', 'med123', 'Medewerker', true),
(4, 'beheer.erik@example.com', 'admin123', 'Beheerder', true),
(5, 'leiding.sarah@example.com', 'lead123', 'Leidinggevende', true),
(6, 'pieter.van@example.com', 'pwd6', 'Klant', true),
(7, 'emma.devries@example.com', 'pwd7', 'Klant', true),
(8, 'med.mark@example.com', 'pwd8', 'Medewerker', true);

-- Additional klanten (customers) - total 6 klanten (including existing klant id 1)
INSERT INTO klanten (klant_id, gebruiker_id, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email) VALUES
(2, 2, 'Anna', NULL, 'Klein', '1992-03-12', '0611122233', 'anna.klein@example.com'),
(3, 6, 'Pieter', 'van', 'Dijk', '1985-07-05', '0622233344', 'pieter.van@example.com'),
(4, 7, 'Emma', NULL, 'de Vries', '1990-11-20', '0633344455', 'emma.devries@example.com'),
(5, NULL, 'Rob', NULL, 'Bakker', '1978-02-28', '0644455566', 'rob.bakker@example.com'),
(6, NULL, 'Lotte', NULL, 'Smit', '1995-06-14', '0655566677', 'lotte.smit@example.com');

-- Ensure there are at least 4 bootsoorten (add Sloep as bootsoort_id = 4)
INSERT INTO bootsoorten (bootsoort_id, naam, beschrijving) VALUES
(4, 'Sloep', 'Kleine, stabiele boot voor ontspannen tochten.');

-- (removed locatie_bootsoorten test mappings; availability derived from boten table)

-- Additional boten to reach at least 10 total boats (existing 3 + 7 added = 10)
INSERT INTO boten
(boot_id, naam, merk, bootsoort_id, capaciteit, bouwjaar, lengte, omschrijving, prijs_per_uur, locatie_id)
VALUES
(4, 'Sun Runner', 'Suzuki', 1, 8, 2019, 8.50, 'Snelle motorboot voor groepen.', 80.00, 1),
(5, 'Wind Dancer', 'Beneteau', 2, 4, 2018, 7.00, 'Zeer wendbare zeilboot.', 50.00, 2),
(6, 'Calm Canoe', 'OldTown', 3, 2, 2022, 3.80, 'Rustige kano voor twee personen.', 15.00, 1),
(7, 'Lake Sloep', 'SloepCo', 4, 6, 2017, 6.00, 'Comfortabele sloep voor gezinnen.', 35.00, 3),
(8, 'Harbor Breeze', 'Mercury', 1, 6, 2020, 7.20, 'Motorboot geschikt voor tochten.', 55.00, 2),
(9, 'Sea Breeze', 'Quicksilver', 4, 8, 2021, 7.50, 'Ruime sloep voor kleine groepen.', 65.00, 1),
(10, 'River Glide', 'MadRiver', 3, 2, 2016, 4.00, 'Snel kano model voor rivieren.', 18.00, 2);

-- Dummy reserveringen to reach at least 10 reservations (including existing id 1)
-- All foreign keys reference existing klanten and boten above; times/dates chosen to avoid overlapping active bookings for same boot.
INSERT INTO reserveringen
 (reservering_id, klant_id, boot_id, datum, begintijd, eindtijd, aantal_personen, status)
VALUES
 (2, 2, 2, '2026-09-15', '09:00:00', '11:00:00', 3, 'Actief'),
 (3, 3, 3, '2026-09-16', '14:00:00', '16:00:00', 2, 'Voltooid'),
 (4, 4, 4, '2026-09-20', '10:00:00', '12:00:00', 5, 'Geannuleerd'),
 (5, 5, 5, '2026-09-21', '13:00:00', '15:00:00', 4, 'Actief'),
 (6, 6, 6, '2026-09-22', '09:00:00', '10:30:00', 2, 'Actief'),
 (7, 2, 7, '2026-09-25', '11:00:00', '13:00:00', 4, 'Actief'),
 (8, 3, 8, '2026-09-26', '15:00:00', '17:00:00', 3, 'Voltooid'),
 (9, 4, 9, '2026-09-27', '10:00:00', '12:00:00', 6, 'Actief'),
 (10, 5, 10, '2026-09-28', '08:00:00', '09:30:00', 2, 'Actief');

