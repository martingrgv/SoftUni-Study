-- 08.CREATE TABLE USERS

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY(1, 1),
	Username VARCHAR(30) NOT NULL,
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

-- 09.
-- You will have to change the PK name
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07F937C434

ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY (Id, Username)

-- 10.
ALTER TABLE Users
ADD CONSTRAINT CHK_PasswordIsAtLeastFiveSymbols
CHECK (LEN([Password]) >= 5)

-- 11.
ALTER TABLE Users
ADD CONSTRAINT df_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime;

-- 12.
ALTER TABLE Users
DROP CONSTRAINT PK_UsersTable

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

ALTER TABLE Users
ADD UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameAtLeastThreeSymbols
CHECK (LEN(Username) >= 3)

-- Test

INSERT INTO Users(Username, [Password])
VALUES ('One Reborn', 'Yahargul Chapel')

--DROP TABLE Users