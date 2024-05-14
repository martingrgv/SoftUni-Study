-- 08.CREATE TABLE USERS

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime TIME,
	IsDeleted BIT
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES ('The Witch of Hemwick', 'TheKeyToRunes', '00:00:00', 0),
	('Father Gascoigne', 'KingofGr@ves!', '23:58:00', 0),
	('Vicar Amelia', 'easyBoss1', '11:12:13', 0),
	('Cleric Beast', 'abc123', '04:11:00', 1),
	('Rom the Vacuous Spider', 'cfcfcfcf', '17:22:11', 1)

-- END OF EXERCISE

SELECT * FROM Users

DROP TABLE Users