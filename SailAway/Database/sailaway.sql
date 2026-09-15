/*
    Project: SailAway Botenverhuur
    Omschrijving: CREATE-script voor MySQL / MariaDB via XAMPP
*/

-- =========================================================
-- DATABASE AANMAKEN
-- =========================================================
DROP DATABASE IF EXISTS sailaway;

CREATE DATABASE sailaway
CHARACTER SET utf8mb4
COLLATE utf8mb4_general_ci;

USE sailaway;

-- =========================================================
-- TABELLEN AANMAKEN
-- =========================================================
CREATE TABLE IF NOT EXISTS klanten
(
    klant_id INT NOT NULL AUTO_INCREMENT,
    voornaam VARCHAR(100) NOT NULL,
    tussenvoegsel VARCHAR(30) NULL,
    achternaam VARCHAR(100) NOT NULL,
    geboortedatum DATE NOT NULL,
    telefoonnummer VARCHAR(30) NOT NULL,
    email VARCHAR(255) NOT NULL,
    wachtwoord VARCHAR(255) NOT NULL,
    PRIMARY KEY (klant_id)
);

CREATE TABLE IF NOT EXISTS bootsoorten
(
    bootsoort_id INT NOT NULL AUTO_INCREMENT,
    naam VARCHAR(100) NOT NULL,
    beschrijving VARCHAR(500) NULL,
    PRIMARY KEY (bootsoort_id)
);

CREATE TABLE IF NOT EXISTS locaties
(
    locatie_id INT NOT NULL AUTO_INCREMENT,
    naam VARCHAR(150) NOT NULL,
    adres VARCHAR(255) NOT NULL,
    beschrijving VARCHAR(500) NULL,
    PRIMARY KEY (locatie_id)
);

CREATE TABLE IF NOT EXISTS boten
(
    boot_id INT NOT NULL AUTO_INCREMENT,
    naam VARCHAR(100) NOT NULL,
    merk VARCHAR(100) NOT NULL,
    bootsoort_id INT NOT NULL,
    capaciteit INT NOT NULL,
    bouwjaar INT NOT NULL,
    lengte DECIMAL(6,2) NOT NULL,
    omschrijving VARCHAR(1000) NULL,
    prijs_per_uur DECIMAL(10,2) NOT NULL,
    locatie_id INT NOT NULL,
    PRIMARY KEY (boot_id)
);

CREATE TABLE IF NOT EXISTS reserveringen
(
    reservering_id INT NOT NULL AUTO_INCREMENT,
    klant_id INT NOT NULL,
    boot_id INT NOT NULL,
    locatie_id INT NOT NULL,
    datum DATE NOT NULL,
    begintijd TIME NOT NULL,
    eindtijd TIME NOT NULL,
    aantal_personen INT NOT NULL,
    status VARCHAR(30) NOT NULL DEFAULT 'Actief',
    PRIMARY KEY (reservering_id)
);

-- Hiermee kan worden vastgelegd welke bootsoorten op welke locaties worden aangeboden.
CREATE TABLE IF NOT EXISTS locatie_bootsoorten
(
    locatie_id INT NOT NULL,
    bootsoort_id INT NOT NULL,
    PRIMARY KEY (locatie_id, bootsoort_id)
);

-- =========================================================
-- ALTERNATE KEYS / UNIQUE KEYS
-- =========================================================
ALTER TABLE klanten
    ADD CONSTRAINT AK_klanten_email UNIQUE (email);

ALTER TABLE bootsoorten
    ADD CONSTRAINT AK_bootsoorten_naam UNIQUE (naam);

ALTER TABLE locaties
    ADD CONSTRAINT AK_locaties_naam UNIQUE (naam);

-- =========================================================
-- FOREIGN KEYS AANMAKEN
-- =========================================================
ALTER TABLE boten
    ADD CONSTRAINT FK_boten_bootsoorten
    FOREIGN KEY (bootsoort_id) REFERENCES bootsoorten(bootsoort_id);

ALTER TABLE boten
    ADD CONSTRAINT FK_boten_locaties
    FOREIGN KEY (locatie_id) REFERENCES locaties(locatie_id);

ALTER TABLE reserveringen
    ADD CONSTRAINT FK_reserveringen_klanten
    FOREIGN KEY (klant_id) REFERENCES klanten(klant_id)
    ON DELETE CASCADE;

ALTER TABLE reserveringen
    ADD CONSTRAINT FK_reserveringen_boten
    FOREIGN KEY (boot_id) REFERENCES boten(boot_id);

ALTER TABLE reserveringen
    ADD CONSTRAINT FK_reserveringen_locaties
    FOREIGN KEY (locatie_id) REFERENCES locaties(locatie_id);

ALTER TABLE locatie_bootsoorten
    ADD CONSTRAINT FK_locatie_bootsoorten_locaties
    FOREIGN KEY (locatie_id) REFERENCES locaties(locatie_id)
    ON DELETE CASCADE;

ALTER TABLE locatie_bootsoorten
    ADD CONSTRAINT FK_locatie_bootsoorten_bootsoorten
    FOREIGN KEY (bootsoort_id) REFERENCES bootsoorten(bootsoort_id)
    ON DELETE CASCADE;

-- =========================================================
-- TESTDATA TOEVOEGEN
-- =========================================================
INSERT IGNORE INTO bootsoorten (bootsoort_id, naam, beschrijving) VALUES
(1, 'Motorboot', 'Boot met motor voor recreatief varen.'),
(2, 'Zeilboot', 'Boot die voornamelijk met zeilen wordt voortbewogen.'),
(3, 'Kano', 'Kleine boot die met een peddel wordt voortbewogen.');

INSERT IGNORE INTO locaties (locatie_id, naam, adres, beschrijving) VALUES
(1, 'Sail Away ''s-Hertogenbosch', 'Botenboulevard 3, ''s-Hertogenbosch', 'Startlocatie in ''s-Hertogenbosch.'),
(2, 'Sail Away Oss', 'Oss', 'Startlocatie in Oss.'),
(3, 'Sail Away Veghel', 'Veghel', 'Startlocatie in Veghel.');

INSERT IGNORE INTO locatie_bootsoorten (locatie_id, bootsoort_id) VALUES
(1, 1), (1, 2),
(2, 2), (2, 3),
(3, 1), (3, 3);

INSERT IGNORE INTO boten
(boot_id, naam, merk, bootsoort_id, capaciteit, bouwjaar, lengte, omschrijving, prijs_per_uur, locatie_id)
VALUES
(1, 'Sea Star', 'Yamaha', 1, 6, 2021, 7.50, 'Comfortabele motorboot voor een dag op het water.', 60.00, 3),
(2, 'Blue Wave', 'Jeanneau', 2, 4, 2020, 6.80, 'Zeilboot voor recreatief varen.', 45.00, 1),
(3, 'River One', 'Wilderness', 3, 2, 2022, 4.20, 'Kano voor twee personen.', 20.00, 2);
