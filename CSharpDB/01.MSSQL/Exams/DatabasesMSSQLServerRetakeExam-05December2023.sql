--01.
CREATE DATABASE RailwaysDb
GO

USE RailwaysDb
GO

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(MAX) NOT NULL
)

CREATE TABLE RailwayStations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Trains(
	Id INT PRIMARY KEY IDENTITY,
	HourOfDeparture NVARCHAR(5) NOT NULL,
	HourOfArrival NVARCHAR(5) NOT NULL,
	DepartureTownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id),
	ArrivalTownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE TrainsRailwayStations(
	TrainId INT FOREIGN KEY REFERENCES Trains(Id),
	RailwayStationId INT FOREIGN KEY REFERENCES RailwayStations(Id),
	CONSTRAINT PK_TrainsRailwayStations
	PRIMARY KEY (TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords(
	Id INT PRIMARY KEY IDENTITY,
	DateOfMaintenance DATE NOT NULL,
	Details NVARCHAR(2000) NOT NULL,
	TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id)
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18, 2) NOT NULL,
	DateOfDeparture DATE NOT NULL,
	DateOfArrival DATE NOT NULL,
	TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

--02.
INSERT INTO Trains(HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId) VALUES 
	('07:00', '19:00', 1, 3),
	('08:30', '20:30', 5, 6),
	('09:00', '21:00', 4, 8),
	('06:45', '03:55', 27, 7),
	('10:15', '12:15', 15, 5);

INSERT INTO TrainsRailwayStations (TrainId,RailwayStationId) VALUES
	(36, 1), (36, 4), (36, 31), (36, 57), (36, 7),
	(37, 13), (37, 54), (37, 60), (37, 16),
	(38, 10), (38, 50), (38, 52), (38, 22),
	(39, 68), (39, 3), (39, 31), (39, 19),
	(40, 41), (40, 7), (40, 52), (40, 13)

INSERT INTO Tickets(Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId) VALUES 
	(90.00, '2023-12-01', '2023-12-01', 36, 1),
	(115.00, '2023-08-02', '2023-08-02', 37, 2),
	(160.00, '2023-08-03', '2023-08-03', 38, 3),
	(225.00, '2023-09-01', '2023-09-02', 39, 21),
	(95.00, '2023-09-02', '2023-09-03', 40, 22)

--03.
UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture)
WHERE MONTH(DateOfDeparture) > 11

UPDATE Tickets
SET DateOfArrival = DATEADD(DAY, 7, DateOfDeparture)
WHERE MONTH(DateOfDeparture) > 11

--04.
DELETE FROM MaintenanceRecords
WHERE TrainId =

DELETE FROM Trains
WHERE DepartureTownId = 3