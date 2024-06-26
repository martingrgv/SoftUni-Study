CREATE DATABASE Minions
USE Minions

CREATE TABLE Minions(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	Age INT,
	TownId INT
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(50)
)

ALTER TABLE Minions
ADD CONSTRAINT FK_TownID 
FOREIGN KEY (TownId) REFERENCES Towns(Id)

-- 04.INSERT RECORDS IN BOTH TABLES

INSERT INTO Towns(Id, [Name])
VALUES (1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES (1, 'Kevin', 22, 1),
	  (2, 'Bob', 15, 3),
	  (3, 'Steward', NULL, 2)

-- END OF EXERCISE

SELECT * FROM Minions
SELECT * FROM Towns

TRUNCATE TABLE Minions

DROP TABLE Minions
DROP TABLE Towns