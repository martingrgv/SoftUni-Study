--01.
CREATE TABLE Passports(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(8)
)

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY,
	FirstName VARCHAR(30),
	Salary DECIMAL(8, 2),
	PassportID INT UNIQUE,
	CONSTRAINT FK_Persons_Passports
	FOREIGN KEY (PassportID)
	REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportID, PassportNumber)
VALUES (101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2')

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID)
VALUES (1, 'Roberto', 43300.00, 102),
	(2, 'Tom', 56100.00, 103),
	(3, 'Yana', 60200.00, 101)

--02.
CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY,
	[Name] VARCHAR(40) UNIQUE,
	EstablishedOn DATE
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY,
	[Name] VARCHAR(40) UNIQUE,
	ManufacturerID INT,
	CONSTRAINT FK_Models_Manufacturers
	FOREIGN KEY (ManufacturerID)
	REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers(ManufacturerID, [Name], EstablishedOn)
VALUES (1, 'BMW', '07/03/1916'),
	(2, 'Tesla', '01/01/2003'),
	(3, 'Lada', '01/05/1966')

INSERT INTO Models(ModelID, [Name], ManufacturerID)
VALUES (101, 'X1', 1),
	(102, 'i6', 1),
	(103, 'Model S', 2),
	(104, 'Model X', 2),
	(105, 'Model 3', 2),
	(106, 'Nova', 3)

--03.
CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	[Name] NVARCHAR(30) UNIQUE
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY,
	[Name] NVARCHAR(30) UNIQUE
)

CREATE TABLE StudentsExams(
	StudentID INT,
	ExamID INT,
	CONSTRAINT PK_StudentsExams
	PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudentsExams_Students
	FOREIGN KEY (StudentID)
	REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_Exams
	FOREIGN KEY (ExamID)
	REFERENCES Exams(ExamID)
)

INSERT INTO Students(StudentID, [Name])
VALUES (1, 'Mila'),
	(2, 'Toni'),
	(3, 'Ron')

INSERT INTO Exams(ExamID, [Name])
VALUES (101, 'SpringMVC'),
	(102, 'Neo4j'),
	(103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES (1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--04.
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	ManagerID INT
	CONSTRAINT FK_Teachers_Managers
	FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID, [Name], ManagerID)
VALUES (101, 'John', NULL),
	(102, 'Maya', 106),
	(103, 'Silvia', 106),
	(104, 'Ted', 105),
	(105, 'Mark', 101),
	(106, 'Greta', 101)

--05.
DROP TABLE Cities
DROP TABLE Customers
DROP TABLE Items
DROP TABLE ItemTypes
DROP TABLE OrderItems
DROP TABLE Orders

CREATE TABLE Cities(
	CityID INT PRIMARY KEY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	CityID INT NOT NULL,
	CONSTRAINT FK_Customer_CityID
	FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY,
	[Name] NVARCHAR(60) NOT NULL,
	ItemTypeID INT,
	CONSTRAINT FK_Items_ItemsType
	FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Orders(
	OrderID INT,
	CustomerID INT NOT NULL,
	CONSTRAINT FK_Orders_CustomerID
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems(
	OrderID INT,
	ItemID INT,
	CONSTRAINT PK_OrdersID_ItemsID
	PRIMARY KEY (OrderID, ItemID),
	CONSTRAINT FK_OrderItems_ItemsID
	FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)