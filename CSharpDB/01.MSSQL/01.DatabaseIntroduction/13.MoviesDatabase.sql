-- 13. Movies Database

CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE,
	[Length] TIME,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating VARCHAR(10),
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
VALUES ('James Cameron'),
	('Steven Spielberg'),
	('Martin Scorsese'),
	('Tim Burton'),
	('Otto Bathurst')

INSERT INTO Genres(GenreName)
VALUES ('Science Fiction'),
	('Crime Drama'),
	('Horror'),
	('Dark Comedy'),
	('Action')

INSERT INTO Categories(CategoryName)
VALUES ('Drama'),
	('Sci-fi'),
	('Action'),
	('Suspense'),
	('Black Comedy')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating)
VALUES ('Peaky Blinders', 5, '2013', '18:00:00', 2, 1, '16+'),
	('Avatar: The Way of Water', 1, NULL, '3:12:00', 1, 2, 'PG-13'),
	('The Wolf of Wall Street', 3, '2007', '3:00:00', 4, 5, 'R'),
	('Jaws', 2, '1975', '2:04:00', 3, 4, 'PG'),
	('Batman', 4, '1989', '2:06:00', 5, 3, 'PG-13')

-- END OF EXERCISE

SELECT Movies.Id, Movies.Title, Directors.DirectorName, Year(CopyrightYear), [Length], Genres.GenreName, Categories.CategoryName, Rating
FROM Movies
INNER JOIN Directors ON Movies.DirectorId=Directors.Id
INNER JOIN Genres ON Movies.GenreId=Genres.Id
INNER JOIN Categories ON Movies.CategoryId=Categories.Id