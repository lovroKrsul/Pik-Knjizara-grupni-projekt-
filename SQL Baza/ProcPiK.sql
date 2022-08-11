---------------------------------------------------------Procedures----------------------------------------------

USE PraKnjizara

---------------------------------------------------------User----------------------------------------------
GO
CREATE OR ALTER PROC LoadUsers
AS
BEGIN 
	SELECT * FROM Person
END
GO

CREATE OR ALTER PROC LoadUserId
	@PersonId INT
AS
BEGIN 
	SELECT *
	FROM Person
	WHERE IDUser = @PersonId
END
GO

CREATE OR ALTER PROC LoadUser
	@Email NVARCHAR(250)
AS
BEGIN 
	SELECT *
	FROM Person
	WHERE Email = @Email
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
	INSERT INTO Person(PersonCode, FirstName, LastName, Email, Password, City, ZipCode, StreetName, StreetNumber, OIB, Workplace)
	VALUES (@PersonCode, @FirstName, @LastName, @Email, @Password, @City, @ZipCode, @StreetName, @StreetNumber, @OIB, @Workplace)
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
END
GO

CREATE OR ALTER PROC LoadBook
	@BookId INT
AS
BEGIN 
	SELECT *
	FROM Book
	WHERE IDBook = @BookId
END
GO
