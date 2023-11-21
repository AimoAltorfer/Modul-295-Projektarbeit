# Modul-295-Projektarbeit

## Setup-Anleitung

1. `SQLQuery.sql` öffnen.
2. SQL MS mit `localhost` verbinden.
3. Query ausführen.
4. Unter `WEB API --> WEB API.sln` öffnen.
5. WEB API ausführen.
6. In Visual Studio Code den Ordner `SkiServiceWebsiteCode` öffnen.
7. Zu `index.html` navigieren.
8. Mit http ausführen.

## Nutzung

- Nun kann man unter "Registrieren" ein neues Ticket erstellen.
- Danach kann man unter "Anmelden" sich einloggen. Beispiel-Benutzer: `Admin`, Passwort: `admin`.
- Man hat nun die Option, ein Ticket zu updaten oder zu löschen.

## Datenbank-Überprüfung

- Die gelöschten Tickets werden in der Tabelle `dbo.DeletedOrders` gespeichert.
- Dies lässt sich mit `SELECT * FROM dbo.DeletedOrders;` überprüfen.
