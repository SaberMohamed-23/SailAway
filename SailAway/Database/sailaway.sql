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

CREATE TABLE klanten
(
    klant_id INT NOT NULL AUTO_INCREMENT,
    voornaam VARCHAR(100) NOT NULL,
    tussenvoegsel VARCHAR(30) NULL,
    achternaam VARCHAR(100) NOT NULL,
    geboortedatum DATE NOT NULL,
    telefoonnummer VARCHAR(30) NOT NULL,
    email VARCHAR(255) NOT NULL,
    wachtwoord VARCHAR(255) NOT NULL,

    CONSTRAINT PK_klanten PRIMARY KEY (klant_id),
    CONSTRAINT AK_klanten_email UNIQUE (email)
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

-- Welke bootsoorten worden op welke locatie aangeboden?
CREATE TABLE locatie_bootsoorten
(
    locatie_id INT NOT NULL,
    bootsoort_id INT NOT NULL,

    CONSTRAINT PK_locatie_bootsoorten PRIMARY KEY (locatie_id, bootsoort_id),
    CONSTRAINT FK_locatie_bootsoorten_locaties
        FOREIGN KEY (locatie_id) REFERENCES locaties(locatie_id)
        ON DELETE CASCADE,
    CONSTRAINT FK_locatie_bootsoorten_bootsoorten
        FOREIGN KEY (bootsoort_id) REFERENCES bootsoorten(bootsoort_id)
        ON DELETE CASCADE
);

CREATE TABLE boten
(
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

    -- Een boot mag alleen een type krijgen dat op die locatie wordt aangeboden.
    CONSTRAINT FK_boten_locatie_bootsoort
        FOREIGN KEY (locatie_id, bootsoort_id)
        REFERENCES locatie_bootsoorten(locatie_id, bootsoort_id),

    CONSTRAINT CK_boten_capaciteit CHECK (capaciteit > 0),
    CONSTRAINT CK_boten_bouwjaar CHECK (bouwjaar BETWEEN 1900 AND 2100),
    CONSTRAINT CK_boten_lengte CHECK (lengte > 0),
    CONSTRAINT CK_boten_prijs CHECK (prijs_per_uur >= 0),

    -- Nodig voor de samengestelde FK vanuit reserveringen.
    CONSTRAINT AK_boten_boot_locatie UNIQUE (boot_id, locatie_id)
);

CREATE TABLE reserveringen
(
    reservering_id INT NOT NULL AUTO_INCREMENT,
    klant_id INT NOT NULL,
    boot_id INT NOT NULL,
    locatie_id INT NOT NULL,
    datum DATE NOT NULL,
    begintijd TIME NOT NULL,
    eindtijd TIME NOT NULL,
    aantal_personen INT NOT NULL,
    status ENUM('Actief', 'Geannuleerd', 'Voltooid') NOT NULL DEFAULT 'Actief',

    CONSTRAINT PK_reserveringen PRIMARY KEY (reservering_id),

    CONSTRAINT FK_reserveringen_klanten
        FOREIGN KEY (klant_id) REFERENCES klanten(klant_id)
        ON DELETE CASCADE,

    -- Hierdoor moet de gekozen reserveringslocatie dezelfde locatie zijn als de boot.
    CONSTRAINT FK_reserveringen_boot_locatie
        FOREIGN KEY (boot_id, locatie_id)
        REFERENCES boten(boot_id, locatie_id),

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

INSERT INTO locatie_bootsoorten (locatie_id, bootsoort_id) VALUES
(1, 1), (1, 2),
(2, 2), (2, 3),
(3, 1), (3, 3);

INSERT INTO boten
(boot_id, naam, merk, bootsoort_id, capaciteit, bouwjaar, lengte, omschrijving, prijs_per_uur, locatie_id)
VALUES
(1, 'Sea Star', 'Yamaha', 1, 6, 2021, 7.50, 'Comfortabele motorboot voor een dag op het water.', 60.00, 3),
(2, 'Blue Wave', 'Jeanneau', 2, 4, 2020, 6.80, 'Zeilboot voor recreatief varen.', 45.00, 1),
(3, 'River One', 'Wilderness', 3, 2, 2022, 4.20, 'Kano voor twee personen.', 20.00, 2);

-- Eenvoudige testklant om reserveringen te kunnen testen.
INSERT INTO klanten
(klant_id, voornaam, tussenvoegsel, achternaam, geboortedatum, telefoonnummer, email, wachtwoord)
VALUES
(1, 'Test', NULL, 'Klant', '2000-01-01', '0612345678', 'test@sailaway.nl', 'test123');

-- Voorbeeldreservering. Deze kan later via de applicatie worden verwijderd.
INSERT INTO reserveringen
(reservering_id, klant_id, boot_id, locatie_id, datum, begintijd, eindtijd, aantal_personen, status)
VALUES
(1, 1, 1, 3, '2026-10-01', '10:00:00', '12:00:00', 4, 'Actief');
