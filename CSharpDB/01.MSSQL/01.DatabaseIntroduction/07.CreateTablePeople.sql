-- 07.CREATE TABLE PEOPLE
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(6, 2),
	[Weight] DECIMAL(6, 2),
	Gender CHAR(1) NOT NULL,
	CONSTRAINT chk_gender check (Gender = 'f' OR Gender = 'm'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Height, [Weight], Gender, Birthdate)
VALUES ('Ivan', 1.87, 76, 'm', '2004-02-12'),
	('Manol', 1.74, 72, 'm', '2000-05-21'),
	('Iva', 1.69, 51, 'f', '2003-10-02'),
	('Mika', 1.72, 61, 'f', '2003-10-15'),
	('Georgi', 1.81, 78, 'm', '2002-01-01')
	
-- END OF EXERCISE

SELECT * FROM People

DROP TABLE People