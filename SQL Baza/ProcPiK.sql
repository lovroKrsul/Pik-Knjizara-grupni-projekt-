---------------------------------------------------------Procedures----------------------------------------------

USE PraKnjizara

---------------------------------------------------------User----------------------------------------------
GO
CREATE OR ALTER PROC LoadUsers
AS
BEGIN 
	SELECT * FROM Person
	WHERE DeletedAt IS NULL
END
GO

CREATE OR ALTER PROC LoadUserId
	@PersonId INT
AS
BEGIN 
	SELECT *
	FROM Person
	WHERE IDUser = @PersonId AND DeletedAt IS NULL
END
GO

CREATE OR ALTER PROC LoadUser
	@Email NVARCHAR(250)
AS
BEGIN 
	SELECT *
	FROM Person
	WHERE Email = @Email AND DeletedAt IS NULL
END
GO

CREATE OR ALTER PROC AddUser
	@PersonCode NVARCHAR(250),
    @FirstName NVARCHAR(250),
    @LastName NVARCHAR(250),
    @Email NVARCHAR(250),
    @Password NVARCHAR(250),
    @City NVARCHAR(250),
    @ZipCode NVARCHAR(250),
    @StreetName NVARCHAR(250),
    @StreetNumber NVARCHAR(250),
    @OIB NVARCHAR(250),
    @Workplace NVARCHAR(250)
AS
BEGIN
	INSERT INTO Person(PersonCode, FirstName, LastName, Email, Password, City, ZipCode, StreetName, StreetNumber, OIB, Workplace, CreatedAt)
	VALUES (@PersonCode, @FirstName, @LastName, @Email, @Password, @City, @ZipCode, @StreetName, @StreetNumber, @OIB, @Workplace, CONVERT(DATE, GETDATE()))
END
GO

CREATE OR ALTER PROC UpdateUser
	@IdUser INT,
	@PersonCode NVARCHAR(250),
    @FirstName NVARCHAR(250),
    @LastName NVARCHAR(250),
    @Email NVARCHAR(250),
    @Password NVARCHAR(250),
    @City NVARCHAR(250),
    @ZipCode NVARCHAR(250),
    @StreetName NVARCHAR(250),
    @StreetNumber NVARCHAR(250),
    @OIB NVARCHAR(250),
    @Workplace NVARCHAR(250)
AS
BEGIN
	Update Person
	Set PersonCode = @PersonCode,
		FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Password = @Password,
		City = @City,
		ZipCode = @ZipCode,
		StreetName = @StreetName,
		StreetNumber = @StreetNumber,
		OIB = @OIB,
		Workplace = @Workplace
	WHERE IDUser = @IdUser
END
GO

CREATE OR ALTER PROC ResetPassword
    @Email NVARCHAR(250),
    @Password NVARCHAR(250)
AS
BEGIN
	Update Person
	Set Password = @Password
	WHERE Email = @Email
END
GO

CREATE OR ALTER PROC DeleteUser
	@IdUser INT,
    @FirstName NVARCHAR(250),
    @LastName NVARCHAR(250),
    @Email NVARCHAR(250),
    @Password NVARCHAR(250),
    @ZipCode NVARCHAR(250),
    @StreetName NVARCHAR(250),
    @StreetNumber NVARCHAR(250)
AS
BEGIN
	Update Person
	Set FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Password = @Password,
		ZipCode = @ZipCode,
		StreetName = @StreetName,
		StreetNumber = @StreetNumber,
		DeletedAt = GETDATE()
	WHERE IDUser = @IdUser
END
GO

CREATE OR ALTER PROC AuthenticateUser
	@email NVARCHAR(50),
	@password NVARCHAR(128)
AS
BEGIN
	SELECT *
	FROM Person
	WHERE Email = @email AND Password = @password 
END
GO

CREATE OR ALTER PROC GetPersonNumber
AS
BEGIN
	SELECT TOP 1 PersonCode
	FROM Person
	WHERE CreatedAt = CONVERT(DATE, GETDATE()) AND PersonCode IS NOT NULL
	ORDER BY IDUser DESC
END
GO

---------------------------------------------------------Autor----------------------------------------------

CREATE OR ALTER PROC DeleteWorker
	@IdUser INT,
    @FirstName NVARCHAR(250),
    @LastName NVARCHAR(250),
    @Email NVARCHAR(250),
    @Password NVARCHAR(250),
	@OIB NVARCHAR(250),
	@Workplace NVARCHAR(250)
AS
BEGIN
	Update Person
	Set FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Password = @Password,
		OIB = @OIB,
		Workplace = @Workplace,
		DeletedAt = GETDATE()
	WHERE IDUser = @IdUser
END
GO

---------------------------------------------------------Autor----------------------------------------------

CREATE OR ALTER PROC [dbo].[DeleteAuthor]
@ID int
as
update Author Set DeletedAt=GETDATE() where Author.IDAuthor=@ID
GO
CREATE OR ALTER PROC [dbo].[LoadAuthorByID]
@ID int
as
select * from Author where DeletedAt is null and IDAuthor=@ID
GO
CREATE OR ALTER proc [dbo].[LoadAuthorByName]
@FirstName nvarchar(50),
@LastName nvarchar(50)
as
select  * from Author where FirstName=@FirstName and LastName=@LastName
GO
CREATE OR ALTER   PROC [dbo].[LoadAuthors]
as
select* from Author where DeletedAt is null
GO

Create Or ALTER Proc [dbo].[UpdateAuthor]
@ID int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Description nvarchar(max),
@Biography nvarchar(max)
as
Begin
update Author set FirstName=@FirstName where Author.IDAuthor=@ID
update Author set LastName=@LastName where Author.IDAuthor=@ID
update Author set Description=@Description where Author.IDAuthor=@ID
update Author set Biography=@Biography where Author.IDAuthor=@ID
End
GO

Create OR ALTER proc [dbo].[UpdateAuthorByName]
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Description nvarchar(max),
@Biography nvarchar(max)
as
Begin
update Author set FirstName=@FirstName where (Author.FirstName=@FirstName and Author.LastName=@LastName)
update Author set LastName=@LastName where (Author.FirstName=@FirstName and Author.LastName=@LastName)
update Author set Description=@Description where (Author.FirstName=@FirstName and Author.LastName=@LastName)
update Author set Biography=@Biography where (Author.FirstName=@FirstName and Author.LastName=@LastName)
End
GO

---------------------------------------------------------Book----------------------------------------------
GO
CREATE OR ALTER PROC LoadBooks
AS
BEGIN 
	SELECT * FROM Book
	WHERE Used = 0 AND DeletedAt IS NULL
END
GO

CREATE OR ALTER PROC LoadBook
	@BookId INT
AS
BEGIN 
	SELECT *
	FROM Book
	WHERE IDBook = @BookId AND Used = 0 AND DeletedAt IS NULL
END
GO

CREATE OR ALTER PROC LoadBookUsed
	@Title NVARCHAR(250)
AS
BEGIN 
	SELECT *
	FROM Book
	WHERE Title = @Title AND Used = 1 AND DeletedAt IS NULL
END
GO

CREATE OR ALTER PROC AddBook
    @Title NVARCHAR(250),
    @AuthorId INT,
    @Description NVARCHAR(250),
    @ISBN NVARCHAR(250),
    @InStock INT,
    @Price MONEY,
    @Publisher NVARCHAR(250),
    @Genre NVARCHAR(250),
    @Tags NVARCHAR(250)
AS
BEGIN
	INSERT INTO Book (Title, AuthorID, Description, ISBN, Used, InStock, Price, Publisher, Ganre, Tags, CreatedAt)
	VALUES(@Title, @AuthorId, @Description, @ISBN, 0, @InStock, @Price, @Publisher, @Genre, @Tags, GETDATE())
	INSERT INTO Book (Title, AuthorID, Description, ISBN, Used, InStock, Price, Publisher, Ganre, Tags, CreatedAt)
	VALUES(@Title, @AuthorId, @Description, @ISBN, 1, @InStock, @Price * 0.8, @Publisher, @Genre, @Tags, GETDATE())
END
GO

CREATE OR ALTER PROC UpdateUser
	@IdBook INT,
    @Title NVARCHAR(250),
    @AuthorId INT,
    @Description NVARCHAR(250),
    @ISBN NVARCHAR(250),
    @InStock INT,
    @Price MONEY,
    @Publisher NVARCHAR(250),
    @Genre NVARCHAR(250),
    @Tags NVARCHAR(250)
AS
BEGIN
	Update Book
	Set Title = @Title,
		AuthorID = @AuthorID,
		Description = @Description,
		ISBN = @ISBN,
		InStock = @InStock,
		Price = @Price,
		Publisher = @Publisher,
		Ganre = @Genre,
		Tags = @Tags
	WHERE IDBook = @IdBook
END
GO

CREATE OR ALTER PROC DeleteBook
	@IdBook INT
AS
BEGIN
	Update Book
	Set DeletedAt = GETDATE()
	WHERE IDBook = @IdBook
END
GO

---------------------------------------------------------Contact----------------------------------------------

CREATE OR ALTER PROC AddContact
	@Name NVARCHAR(250),
	@Email NVARCHAR(250),
	@Message NVARCHAR(250)
AS
BEGIN
	INSERT INTO Contact(Name, Email, Message, Viewed, CreatedAt)
	VALUES (@Name, @Email, @Message, 0, GETDATE())
END
GO

CREATE OR ALTER PROC LoadContacts
AS
BEGIN
	SELECT * 
	FROM Contact
END
GO

CREATE OR ALTER PROC ContactViewed
	@IdContact INT
AS
BEGIN
	UPDATE Contact
	SET Viewed = 1
	WHERE IdContact = @IdContact
END
GO