SAILAWAY - MYSQL / XAMPP DATABASE
================================

Deze versie is afgestemd op de SailAway-usecases uit de projectbronnen.

BELANGRIJKSTE TABELLEN
- klanten
- bootsoorten
- locaties
- locatie_bootsoorten
- boten
- reserveringen

WAT IS EXTRA GECONTROLEERD?
- klanten zoeken op achternaam / telefoonnummer / email
- boten gekoppeld aan bootsoort + locatie
- locatie bepaalt welke bootsoorten aangeboden mogen worden
- reservering bevat datum, begin/eindtijd, locatie, aantal personen en status
- status = Actief / Geannuleerd / Voltooid
- dubbele boeking van dezelfde boot wordt door database-trigger geblokkeerd
- aantal personen mag niet hoger zijn dan bootcapaciteit
- indexes toegevoegd voor zoeken/filteren/beschikbaarheid

DATABASE IMPORTEREN
1. Start Apache en MySQL in XAMPP.
2. Open http://localhost/phpmyadmin
3. Klik op Importeren.
4. Kies SailAway/Database/sailaway.sql.
5. Klik op Importeren / Go.

LET OP
Het script begint met DROP DATABASE IF EXISTS sailaway.
Bij opnieuw importeren wordt de bestaande SailAway-database dus opnieuw opgebouwd.

DATABASEVERBINDING
SailAway/Database/DatabaseConnection.cs

Standaard:
Server   = 127.0.0.1
Port     = 3306
Database = sailaway
User     = root
Password = leeg

Zie ook:
SailAway/Database/USECASE_DATABASE_MAPPING.txt
