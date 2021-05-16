--CREATE DATABASE MyVapeStoreDB;
--GO

USE MyVapeStoreDB;
GO

--ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF
--GO


CREATE TABLE Postnummer (
	Postnummer int PRIMARY KEY,
	Bynavn varchar(75)
);

CREATE TABLE Firma (
	FirmaID int IDENTITY(1,1) PRIMARY KEY,
	Navn varchar(75) NOT NULL,
	Email varchar(100) NOT NULL,
	Teleforn int NOT NULL
);

CREATE TABLE Vare (
	VareID int IDENTITY(1,1) PRIMARY KEY,
	Navn varchar(75) NOT NULL,
	Prise float NOT NULL,
	Antal int DEFAULT NULL,
	FirmaID int FOREIGN KEY REFERENCES Firma(FirmaID) NOT NULL,
);

CREATE TABLE Kunder (
	KundeID int IDENTITY(1,1) PRIMARY KEY,
	Fornavn varchar(75) NOT NULL,
	Efternavn varchar(75) NOT NULL,
	Email varchar(100),
	Mobil int NOT NULL,
	Aktiv bit DEFAULT 1,
	OpretDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Addresse (
	AddresseID int IDENTITY(1,1) PRIMARY KEY,
	Postnummer int FOREIGN KEY REFERENCES Postnummer(Postnummer),
	Vej varchar(70) NOT NULL,
	KundeID int FOREIGN KEY REFERENCES Kunder(KundeID) NOT NULL
);

CREATE TABLE MyOrder (
	OrderID int IDENTITY(1,1) PRIMARY KEY,
	KundeID int FOREIGN KEY REFERENCES Kunder(KundeID) NOT NULL,
	AddresseID int FOREIGN KEY REFERENCES Addresse(AddresseID) NOT NULL,
	OpretDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE VareOrder (
	VareOrderID int IDENTITY(1,1) PRIMARY KEY,
	OrderID int FOREIGN KEY REFERENCES MyOrder(OrderID) NOT NULL,
	VareID int FOREIGN KEY REFERENCES Vare(VareID) NOT NULL,
	Antal int DEFAULT 1,
	Prise float DEFAULT NULL,
	SendtDate datetime DEFAULT null
);

CREATE VIEW VKunder AS
SELECT dbo.Kunder.KundeID, dbo.Kunder.Fornavn + ' ' + dbo.Kunder.Efternavn AS [Kundes Navn], dbo.Kunder.Email, dbo.Kunder.Mobil, dbo.Kunder.Aktiv, dbo.Kunder.OpretDate, dbo.Postnummer.Postnummer, dbo.Postnummer.Bynavn, 
                  dbo.Addresse.Vej
FROM     dbo.Kunder INNER JOIN
                  dbo.Addresse ON dbo.Kunder.KundeID = dbo.Addresse.KundeID INNER JOIN
                  dbo.Postnummer ON dbo.Addresse.Postnummer = dbo.Postnummer.Postnummer


CREATE VIEW VOrderList AS
SELECT dbo.MyOrder.OpretDate, dbo.MyOrder.OrderID, dbo.Kunder.KundeID, dbo.Kunder.Fornavn + ' ' + dbo.Kunder.Efternavn AS [Hellet Navnet], dbo.Addresse.Vej, dbo.Postnummer.Postnummer, dbo.Postnummer.Bynavn, 
                  dbo.Vare.Navn AS [Vare Navn], dbo.VareOrder.Antal, dbo.VareOrder.Prise, dbo.VareOrder.SendtDate
FROM     dbo.Addresse INNER JOIN
                  dbo.Kunder ON dbo.Addresse.KundeID = dbo.Kunder.KundeID INNER JOIN
                  dbo.MyOrder ON dbo.Addresse.AddresseID = dbo.MyOrder.AddresseID AND dbo.Kunder.KundeID = dbo.MyOrder.KundeID INNER JOIN
                  dbo.Postnummer ON dbo.Addresse.Postnummer = dbo.Postnummer.Postnummer INNER JOIN
                  dbo.VareOrder ON dbo.MyOrder.OrderID = dbo.VareOrder.OrderID INNER JOIN
                  dbo.Vare ON dbo.VareOrder.VareID = dbo.Vare.VareID
CREATE VIEW VVareMedFirmaInfo AS
SELECT dbo.Vare.VareID, dbo.Vare.Navn, dbo.Vare.Antal, dbo.Vare.Prise, dbo.Firma.Navn AS [Firma Navn], dbo.Firma.Email, dbo.Firma.Teleforn
FROM     dbo.Vare INNER JOIN
                  dbo.Firma ON dbo.Vare.FirmaID = dbo.Firma.FirmaID

CREATE VIEW VPaaLager AS
SELECT dbo.Vare.VareID, dbo.Vare.Navn, dbo.Lager.Antal AS [På Lager], dbo.Vare.Prise
FROM     dbo.Vare INNER JOIN
				  dbo.Lager ON dbo.Vare.VareID = dbo.Lager.VareID

CREATE PROCEDURE SPFaaKundeOrder @KundeID int, @OrderID int, @navn varchar(70)
AS
SELECT * FROM VOrderList WHERE KundeID = @KundeID or OrderID = @OrderID or [Kundes Hellet Navnet] = @navn