--01.
SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName, 2) = 'Sa'

--02.
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--03.
SELECT FirstName
FROM Employees
WHERE DepartmentID IN ( 3, 10)
	AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--04.
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--05.
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name] ASC

--06.
SELECT TownId, [Name]
FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC

--07.
SELECT TownId, [Name]
FROM Towns
WHERE NOT LEFT([Name], 1) IN ('R', 'B', 'D')
ORDER BY [Name] ASC

--08.
--CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

--09.
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--10.
SELECT 
	EmployeeId
	, FirstName
	, LastName
	, Salary
	, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC