CREATE DATABASE Accounting
GO 

USE Accounting
GO

--01.
CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Vendors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(id) NOT NULL
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(id) NOT NULL
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL
)

CREATE TABLE Invoices(
	Id INT PRIMARY KEY IDENTITY,
	Number INT UNIQUE NOT NULL,
	IssueDate DATETIME2 NOT NULL,
	DueDate DATETIME2 NOT NULL,
	Amount Decimal (18, 2) NOT NULL,
	Currency VARCHAR(5) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
)

CREATE TABLE ProductsClients(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	ClientId INT FOREIGN KEY REFERENCES Clients(Id)
	CONSTRAINT PK_ProductsClients
	PRIMARY KEY (ProductId, ClientId)
)

--02.
INSERT INTO Products([Name], Price, CategoryId, VendorId) VALUES
	('SCANIA Oil Filter XD01', 78.69, 1, 1),
	('MAN Air Filter XD01',	97.38, 1, 5),
	('DAF Light Bulb 05FG87', 55.00, 2, 13),
	('ADR Shoes 47-47.5', 49.85, 3,	5),
	('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices(Number, IssueDate, DueDate, Amount, Currency, ClientId) VALUES
	(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN',	3),
	(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR',	13),
	(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD',	19)

--03.
UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE DATEPART(MONTH, IssueDate) = 11 AND
	DATEPART(YEAR, IssueDate) = 2022

UPDATE Clients
SET AddressId = 3
WHERE [Name] LIKE '%CO%'

--04.
DECLARE @ClientsToDelete TABLE(Id INT)

INSERT INTO @ClientsToDelete
	SELECT Id FROM Clients
	WHERE LEFT(NumberVAT, 2) = 'IT'

DELETE FROM ProductsClients
WHERE ClientId IN (SELECT Id FROM @ClientsToDelete)

DELETE FROM Invoices
WHERE ClientId IN (SELECT Id FROM @ClientsToDelete)

DELETE FROM Clients
WHERE Id IN (SELECT Id FROM @ClientsToDelete)

--05.
SELECT 
	Number,
	Currency
FROM Invoices
ORDER BY Amount DESC, DueDate ASC

--06.
SELECT
	p.Id,
	p.[Name],
	p.Price,
	c.[Name] AS CategoryName
FROM Products AS p
JOIN Categories AS c ON p.CategoryId = c.Id
WHERE c.[Name] IN ('ADR', 'Others')
ORDER BY Price DESC

--07.
SELECT 
	c.Id,
	c.[Name] AS Client,
	CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', cou.[Name])
FROM Clients AS c
JOIN Addresses AS a ON c.AddressId = a.Id
JOIN Countries AS cou ON a.CountryId = cou.Id
WHERE c.Id NOT IN (SELECT ClientId FROM ProductsClients)
ORDER BY c.[Name]

--08.
SELECT TOP 7
	Number,
	Amount,
	c.[Name]
FROM Invoices AS i
JOIN Clients AS c ON i.ClientId = c.Id
WHERE IssueDate <= '2023-01-01' AND
	Currency = 'EUR' OR
	Amount >= 500 AND
	LEFT(NumberVAT, 2) LIKE '%DE%'
ORDER BY Number, Amount DESC

--09.
SELECT 
	c.[Name] AS Client,
	MAX(p.Price) AS Price,
	c.NumberVAT AS [VAT Number]
FROM ProductsClients AS pc
JOIN Products AS p ON pc.ProductId = p.Id
JOIN Clients AS c ON pc.ClientId = c.Id
WHERE RIGHT(c.[Name], 2) NOT LIKE '%KG%'
GROUP BY c.[Name], c.NumberVAT
ORDER BY Price DESC

--10.
SELECT
	c.[Name] AS Client,
	FLOOR(AVG(p.Price)) AS [Average Price]
FROM ProductsClients AS pc
JOIN Products AS p ON pc.ProductId = p.Id
JOIN Clients AS c ON pc.ClientId = c.Id
JOIN Vendors AS v ON p.VendorId = v.Id
WHERE LEFT(v.NumberVAT, 2) LIKE '%FR%'
GROUP BY c.[Name]
ORDER BY [Average Price], c.[Name] DESC

--11.
CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT
AS
BEGIN
	RETURN(
	SELECT 
		COUNT(*)
	FROM ProductsClients AS pc
	JOIN Products AS p ON pc.ProductId = p.Id
	WHERE p.[Name] = @name)
END

--END OF ASSIGNMENT

SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X')

--12.
CREATE PROCEDURE usp_SearchByCountry(
	@country VARCHAR(10))
AS
BEGIN
	SELECT 
		v.[Name] AS Vendor,
		NumberVAT AS VAT,
		CONCAT(StreetName, ' ', StreetNumber) AS [Street Info],
		CONCAT(City, ' ', PostCode)
	FROM Vendors AS v
	JOIN Addresses AS a ON v.AddressId = a.Id
	JOIN Countries AS c ON a.CountryId = c.Id
	WHERE c.[Name] = @country
	ORDER BY v.[Name], City
END

EXEC usp_SearchByCountry 'France'