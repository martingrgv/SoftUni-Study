--01.
SELECT
	COUNT(*) AS [Count]
FROM WizzardDeposits

--02.
SELECT
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

--03.
SELECT
	DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--04.
SELECT TOP 2
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) ASC

--05.
SELECT
	DepositGroup
	,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--06.
SELECT
	DepositGroup
	,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--07.
SELECT
	DepositGroup
	,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--08.
SELECT 
	DepositGroup
	,MagicWandCreator
	,MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup ASC

--09.
SELECT AgeGroup, COUNT(*) AS Wizards
FROM
(
	SELECT 
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN Age >= 61 THEN '[61+]'
		END AS AgeGroup
	FROM WizzardDeposits
) AS AgeGroups
GROUP BY AgeGroup

--10.
SELECT FirstLetter
FROM
(
	SELECT DISTINCT
		LEFT(FirstName, 1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY FirstName
) AS WizardsTrollChestDeposi
ORDER BY FirstLetter ASC

--11.
SELECT
	DepositGroup
	,IsDepositExpired
	,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate >= '01.01.1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

--12.
SELECT SUM([Difference]) AS SumDifference
FROM
(
SELECT 
	FirstName AS HostWizzard,
	DepositAmount AS HostWizzardDeposit,
	LEAD(FirstName) OVER (ORDER BY Id) AS GuestWizzard,
	LEAD([DepositAmount]) OVER (ORDER BY Id) AS GuestWizzardDeposit,
	(DepositAmount - LEAD([DepositAmount]) OVER (ORDER BY Id)) AS [Difference]
FROM WizzardDeposits
) AS SubQuery

--13.
SELECT
	DepartmentID
	,SUM(Employees.Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14.
SELECT
	DepartmentID
	,MIN(Employees.Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7)
AND HireDate > '01.01.2000'
GROUP BY DepartmentID
ORDER BY DepartmentID

--15.
SELECT * INTO RicherEmployees
FROM Employees
WHERE Salary > 30000

DELETE FROM RicherEmployees
WHERE ManagerID = 42

UPDATE RicherEmployees
SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
	DepartmentId
	,AVG(Salary) AS AvarageSalary
FROM RicherEmployees
GROUP BY DepartmentID

--16.
SELECT
	DepartmentID
	,MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17.
SELECT
	COUNT(*) AS Count
FROM Employees
WHERE ManagerID IS NULL

--18.
SELECT 
	DepartmentID
	,ThirdRanking 
FROM
(
	SELECT
		DepartmentID
		,MAX(Salary) AS ThirdRanking
		,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRanking
	FROM Employees
	GROUP BY DepartmentID, Salary
) AS SubQuery
WHERE SubQuery.SalaryRanking = 3

--19.
WITH DepartmentAvarageSalaries AS
(
	SELECT 
		DepartmentID, AVG(Salary) AS AvarageSalary
	FROM Employees
	GROUP BY DepartmentID
)
SELECT TOP 10
	FirstName, LastName, e.DepartmentID
FROM Employees AS e
JOIN DepartmentAvarageSalaries AS das ON das.DepartmentID = e.DepartmentID
WHERE e.Salary > das.AvarageSalary
ORDER BY e.DepartmentID