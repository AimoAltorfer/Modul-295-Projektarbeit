-- Überprüfen, ob die Datenbank existiert, und sie erstellen, falls nicht
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'SkiServiceManagement')
BEGIN
    CREATE DATABASE SkiServiceManagement;
END
GO

USE SkiServiceManagement;
GO

-- Überprüfen, ob die Tabelle ServiceOrders existiert, und sie erstellen, falls nicht
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ServiceOrders') AND type in (N'U'))
BEGIN
    CREATE TABLE ServiceOrders (
        ServiceOrderID INT PRIMARY KEY IDENTITY(1,1),
        CustomerName NVARCHAR(100),
        CustomerEmail NVARCHAR(100),
        CustomerPhone NVARCHAR(20),
        Priority NVARCHAR(50),
        ServiceType NVARCHAR(100),
        CreateDate DATETIME,
        PickupDate DATETIME,
        Status NVARCHAR(50) DEFAULT 'Offen'
    );
END
GO

-- Überprüfen, ob die Tabelle Employees existiert, und sie erstellen, falls nicht
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Employees') AND type in (N'U'))
BEGIN
    CREATE TABLE Employees (
        EmployeeID INT PRIMARY KEY IDENTITY(1,1),
        Username NVARCHAR(50) UNIQUE,
        PasswordHash VARBINARY(128)
        -- Weitere Felder wie Name, Kontaktinformationen usw. können hier hinzugefügt werden
    );
END
GO

-- Einfügen des Admins, wenn er nicht existiert
IF NOT EXISTS (SELECT * FROM Employees WHERE Username = 'admin')
BEGIN
    INSERT INTO Employees (Username, PasswordHash)
    VALUES ('admin', CONVERT(VARBINARY(128), HASHBYTES('SHA2_256', 'admin')));
END

-- Einfügen von 10 weiteren Mitarbeitern, wenn sie nicht existieren
IF NOT EXISTS (SELECT * FROM Employees WHERE Username = 'mitarbeiter1')
BEGIN
    INSERT INTO Employees (Username, PasswordHash)
    VALUES ('mitarbeiter1', CONVERT(VARBINARY(128), HASHBYTES('SHA2_256', 'passwort1')));
END

IF NOT EXISTS (SELECT * FROM Employees WHERE Username = 'mitarbeiter2')
BEGIN
    INSERT INTO Employees (Username, PasswordHash)
    VALUES ('mitarbeiter2', CONVERT(VARBINARY(128), HASHBYTES('SHA2_256', 'passwort2')));
END

-- Fügen Sie ähnliche Blöcke für mitarbeiter3 bis mitarbeiter10 hinzu


-- theoretisch weitere Beispiele



-- Überprüfen, ob die Tabelle DeletedOrders existiert, und sie erstellen, falls nicht
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'DeletedOrders') AND type in (N'U'))
BEGIN
    CREATE TABLE DeletedOrders (
        DeletedOrderID INT PRIMARY KEY IDENTITY(1,1),
		OriginalServiceOrderID INT,
        CustomerName NVARCHAR(100),
        CustomerEmail NVARCHAR(100),
        CustomerPhone NVARCHAR(20),
        Priority NVARCHAR(50),
        ServiceType NVARCHAR(100),
        Status NVARCHAR(50) DEFAULT 'Gelöscht'
    );
END
GO
