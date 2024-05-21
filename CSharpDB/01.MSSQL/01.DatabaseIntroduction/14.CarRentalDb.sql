-- 14. Car Rental Database

CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories(
	Id BIGINT PRIMARY KEY IDENTITY(1, 1),
	CategoryName NVARCHAR(50),
	DailyRate DECIMAL(4, 2),
	WeeklyRate DECIMAL(6, 2),
	MonthlyRate DECIMAL(8, 2),
	WeekendRate DECIMAL(6, 2)
)

CREATE TABLE Cars(
	Id BIGINT PRIMARY KEY IDENTITY(1, 1),
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(40) NOT NULL,
	Model VARCHAR(20) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId BIGINT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(30),
	Available bit NOT NULL
)

CREATE TABLE Employees(
	Id BIGINT PRIMARY KEY IDENTITY(1, 1),
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(30),
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers(
	Id BIGINT PRIMARY KEY IDENTITY(1, 1),
	DriverLicenseNumber NVARCHAR(10) NOT NULL,
	FullName VARCHAR(60) NOT NULL,
	[Address] VARCHAR(50) NOT NULL,
	City VARCHAR(30) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RentalOrders(
	Id BIGINT PRIMARY KEY IDENTITY(1, 1),
	EmployeeId BIGINT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId BIGINT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId BIGINT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel DECIMAL(4, 2) NOT NULL,
	KilometrageStart BIGINT NOT NULL,
	KilometrageEnd BIGINT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays BIGINT NOT NULL,
	RateApplied BIT NOT NULL,
	TaxRate DECIMAL(8, 2),
	OrderStatus VARCHAR(50),
	Notes VARCHAR(MAX)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('B1', 1.1, 1.2, 1.3, 1.25),
	('B2', 1.3, 1.4, 1.5, 1.35),
	('B', 1.5, 1.7, 1.8, 2)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available)
VALUES ('TX2031AP', 'Audi', 'A3', '2007', 3, 4, 'New', 1),
	('B1111CC', 'BMW', '550i', '2008', 3, 4, 'Used', 1),
	('XAXAXAXA', 'Mercedes-Benz', 'GLS600', '2022', 3, 4, 'New', 1)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES ('Mitko', 'Pishtova', 'Dealer'),
	('Mitko', 'Nepishtova', 'Dealer'),
	('Mitko', 'Pripishtova', 'Dealer')

INSERT INTO Customers(DriverLicenseNumber, FullName, [Address], City, ZIPCode)
VALUES ('XB91AA', 'Ivan Stanimirov Petrov', 'ulitsa Klokotnitsa', 'Sofia', 1000),
	('1928WQ', 'Milen Petrov Georgiev', 'ulitsa Georgi Asparuhov', 'Sofia', 1000),
	('1I02U3', 'Georgi Georgiev Georgiev', 'ulitsa Georgi Georgiev', 'Sofia', 1000)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, TotalDays, RateApplied)
VALUES ('1', '3', '1', 66, 11000, 50000, '2024', '2025', 365, 1),
	('2', '2', '2', 80, 350000, 500000, '2024', '2025', 365, 1),
	('3', '2', '3', 95, 1000, 100200, '2024', '2025', 365, 1)