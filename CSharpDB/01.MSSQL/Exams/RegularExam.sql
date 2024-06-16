CREATE DATABASE LibraryDb
GO

USE LibraryDb
GO

--01.
CREATE TABLE Contacts(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(20),
	PostAddress NVARCHAR(200),
	Website NVARCHAR(50)
)

CREATE TABLE Authors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Books(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) UNIQUE NOT NULL,
	AuthorId INT FOREIGN KEY REFERENCES Authors(Id) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
)

CREATE TABLE Libraries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE LibrariesBooks(
	LibraryId INT FOREIGN KEY REFERENCES Libraries(Id),
	BookId INT FOREIGN KEY REFERENCES Books(Id),
	CONSTRAINT PK_LibrariesBooks
	PRIMARY KEY (LibraryId, BookId)
)

--02.
INSERT INTO Contacts(Email, PhoneNumber, PostAddress, Website) VALUES
	(NULL, NULL, NULL, NULL),
	(NULL, NULL, NULL, NULL),
	('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
	('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

INSERT INTO Authors([Name], ContactId) VALUES
	('George Orwell', 21),
	('Aldous Huxley', 22),
	('Stephen King', 23),
	('Suzanne Collins', 24)

INSERT INTO Books(Title, YearPublished, ISBN, AuthorId, GenreId) VALUES
('1984', 1949, '9780451524935', 16, 2),
('Animal Farm', 1945, '9780451526342', 16, 2),
('Brave New World',	1932, '9780060850524', 17, 2),
('The Doors of Perception',	1954, '9780060850531', 17, 2),
('The Shining', 1977, '9780307743657', 18, 9),
('It', 1986, '9781501142970', 18, 9),
('The Hunger Games', 2008, '9780439023481', 19, 7),
('Catching Fire', 2009, '9780439023498', 19, 7),
('Mockingjay', 2010, '9780439023511', 19, 7)

INSERT INTO LibrariesBooks(LibraryId, BookId) VALUES
(1, 36),
(1, 37),
(2, 38),
(2, 39),
(3, 40),
(3, 41),
(4, 42),
(4, 43),
(5, 44)

--03.Update
UPDATE c
SET Website = CONCAT('www.', LOWER(REPLACE(a.[Name], ' ', '')), '.com')
FROM Contacts AS c
JOIN Authors AS a ON a.ContactId = c.Id
WHERE c.Id IN (
	SELECT c.Id FROM Authors AS a
	JOIN Contacts AS c ON a.ContactId = c.Id
	WHERE c.Website IS NULL
)

--04.
DECLARE @AuthorsToDelete TABLE (Id INT)

INSERT INTO @AuthorsToDelete
	SELECT Id
	FROM Authors
	WHERE [Name] = 'Alex Michaelides'

DELETE FROM LibrariesBooks
WHERE BookId IN (
	SELECT Id 
	FROM Books
	WHERE AuthorId IN (SELECT Id FROM @AuthorsToDelete)
)

DELETE FROM Books
WHERE AuthorId IN (SELECT Id FROM @AuthorsToDelete)

DELETE FROM Authors
WHERE Id IN (SELECT Id FROM @AuthorsToDelete)

--05.
SELECT 
	Title AS [Book Title],
	ISBN,
	YearPublished
FROM Books
ORDER BY YearPublished DESC, Title

--06.
SELECT 
	b.Id,
	Title,
	ISBN,
	g.[Name] AS Genre
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
WHERE g.[Name] IN ('Biography', 'Historical Fiction')
ORDER BY g.[Name], b.Title

--07.
SELECT DISTINCT
	l.[Name] AS [Library],
	c.Email
FROM LibrariesBooks AS lb
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Books AS b ON lb.BookId = b.Id
JOIN Genres AS g ON b.GenreId = g.Id
JOIN Contacts AS c ON l.ContactId = c.Id
WHERE g.[Name] != 'Mystery' AND
	l.[Name] != 'City Lights'
ORDER BY l.[Name]

--08.
SELECT TOP 3
	Title,
	YearPublished AS [Year],
	g.[Name] AS Genre
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
WHERE (YearPublished > 2000 AND
	Title LIKE '%a%') OR
	(YearPublished < 1950 AND
	g.[Name] LIKE '%Fantasy%')
ORDER BY Title, YearPublished DESC

--09.
SELECT 
	a.[Name] AS Author,
	c.Email,
	c.PostAddress AS [Address]
FROM Authors AS a
JOIN Contacts AS c ON a.ContactId = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.[Name]

--10.
SELECT
	a.[Name] AS Author,
	b.Title,
	l.[Name] AS [Library],
	c.PostAddress AS [Library Address]
FROM LibrariesBooks AS lb
JOIN Books AS b ON lb.BookId = b.Id
JOIN Genres AS g ON b.GenreId = g.Id
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Authors AS a ON b.AuthorId = a.Id
JOIN Contacts AS c ON l.ContactId = c.Id
WHERE g.[Name] IN ('Fiction') AND
	c.PostAddress LIKE '%Denver%'
ORDER BY b.Title

--11.
CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
	RETURN(	
		SELECT
			COUNT(*)
		FROM LibrariesBooks AS lb
		JOIN Books AS b ON lb.BookId = b.Id
		JOIN Libraries AS l ON lb.LibraryId = l.Id
		JOIN Authors AS a ON b.AuthorId = a.Id
		WHERE a.[Name] = @name
	)
END

--12.
CREATE PROCEDURE usp_SearchByGenre(@genreName NVARCHAR(30))
AS
BEGIN
	SELECT 
		Title,
		YearPublished AS [Year],
		ISBN,
		a.[Name] AS Author,
		g.[Name] AS Genre
	FROM Books AS b
	JOIN Authors AS a ON b.AuthorId = a.Id
	JOIN Genres AS g ON b.GenreId = g.Id
	WHERE g.[Name] = @genreName
	ORDER BY Title
END

EXEC usp_SearchByGenre 'Fantasy'