SAILAWAY - MYSQL / XAMPP DATABASE
================================

Wat is toegevoegd?
- Models/Klant.cs
- Models/Boot.cs
- Models/Bootsoort.cs
- Models/Locatie.cs
- Models/Reservering.cs
- Models/LocatieBootsoort.cs
- Database/DatabaseConnection.cs
- Database/sailaway.sql
- NuGet package MySqlConnector

DATABASE AANMAKEN IN XAMPP
1. Start Apache en MySQL in het XAMPP Control Panel.
2. Open phpMyAdmin.
3. Kies Importeren / Import.
4. Selecteer SailAway/Database/sailaway.sql.
5. Voer het script uit. De database 'sailaway' wordt automatisch aangemaakt.

DATABASEVERBINDING
De verbinding staat in:
SailAway/Database/DatabaseConnection.cs

Standaard XAMPP instellingen die in het project staan:
Server   = 127.0.0.1
Port     = 3306
Database = sailaway
User     = root
Password = leeg

Als jouw MySQL root-gebruiker wel een wachtwoord heeft, pas alleen Password= aan.

VERBINDING TESTEN IN CODE
Je kunt later bijvoorbeeld gebruiken:

using SailAway.Database;

if (DatabaseConnection.TestConnection(out string message))
{
    MessageBox.Show(message);
}
else
{
    MessageBox.Show(message);
}

BELANGRIJK
- De bestaande Windows Forms interfaces zijn niet vervangen.
- Er is nog geen CRUD repository/service code toegevoegd; dit pakket bevat de databaseverbinding en models.
- De database gebruikt de tabellen: klanten, bootsoorten, locaties, boten, reserveringen en locatie_bootsoorten.
- Voor een echte productie-app hoort een wachtwoord gehasht te worden. Voor deze eenvoudige schoolopdracht is het model bewust eenvoudig gehouden.
