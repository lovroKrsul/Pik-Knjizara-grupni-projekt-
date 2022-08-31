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

---------------------------------------------------------Worker----------------------------------------------

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

CREATE OR ALTER PROC LoadMostPopularBooks
AS
BEGIN 
	SELECT TOP 4 B.Title
	FROM Purchase AS P
	INNER JOIN Book AS B ON P.BookID = B.IDBook
	GROUP BY B.Title
	ORDER BY COUNT(*) DESC
END
GO

CREATE OR ALTER PROC LoadBook
	@BookId INT
AS
BEGIN 
	SELECT *
	FROM Book
	WHERE IDBook = @BookId AND DeletedAt IS NULL
END
GO

CREATE OR ALTER PROC LoadBookByTitle
	@Title NVARCHAR(250)
AS
BEGIN 
	SELECT *
	FROM Book
	WHERE Title = @Title AND Used = 0 AND DeletedAt IS NULL
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
	@Cover NVARCHAR(MAX),
    @Publisher NVARCHAR(250),
    @Genre NVARCHAR(250),
    @Tags NVARCHAR(250)
AS
BEGIN
	INSERT INTO Book (Title, AuthorID, Description, ISBN, Used, InStock, Price, Cover, Publisher, Ganre, Tags, CreatedAt)
	VALUES(@Title, @AuthorId, @Description, @ISBN, 0, @InStock, @Price, @Cover, @Publisher, @Genre, @Tags, GETDATE())
	INSERT INTO Book (Title, AuthorID, Description, ISBN, Used, InStock, Price, Cover, Publisher, Ganre, Tags, CreatedAt)
	VALUES(@Title, @AuthorId, @Description, @ISBN, 1, @InStock, @Price * 0.8, @Cover, @Publisher, @Genre, @Tags, GETDATE())
END
GO

CREATE OR ALTER PROC UpdateBook
	@IdBook INT,
    @Title NVARCHAR(250),
    @AuthorId INT,
    @Description NVARCHAR(250),
    @ISBN NVARCHAR(250),
    @InStock INT,
    @Price MONEY,
	@Cover NVARCHAR(MAX),
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
		Cover = @Cover,
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

---------------------------------------------------------Book purchase----------------------------------------------

CREATE OR ALTER PROC AddPurchase
	@InStorePayment BIT,
	@Payed BIT,
	@Delivery BIT,
	@UserId INT,
	@BookId INT
AS
BEGIN
	UPDATE Book
	SET InStock = InStock - 1
	WHERE IDBook = @BookId
	INSERT INTO Purchase (CreatedAt, InStorePayment, Payed, Delivery, UserId, BookID)
	VALUES (GETDATE(), @InStorePayment, @Payed, @Delivery, @UserId, @BookId)
	SELECT SCOPE_IDENTITY() AS IdPurchase
END
GO

CREATE OR ALTER PROC AddBorrow
	@ReturnDate DATETIME,
	@InStorePayment BIT,
	@Payed BIT,
	@Delivery BIT,
	@UserId INT,
	@BookId INT
AS
BEGIN
	UPDATE Book
	SET InStock = InStock - 1
	WHERE IDBook = @BookId
	INSERT INTO BorrowBook (CreatedAt, ReturnDate, Returned , InStorePayment, Payed, Delivery, BookstoreId, UserId, BookId)
	VALUES (GETDATE(), @ReturnDate, 0, @InStorePayment, @Payed, @Delivery, 1, @UserId, @BookId)
	SELECT SCOPE_IDENTITY() AS IdBorrow
END
GO

CREATE OR ALTER PROC PayPurchase
	@IdPurchase INT
AS 
BEGIN
	UPDATE Purchase
	SET Payed = 1
	WHERE IDPurchase = @IdPurchase
END
GO

CREATE OR ALTER PROC PayBorrow
	@IdBorrow INT
AS 
BEGIN
	UPDATE BorrowBook
	SET Payed = 1
	WHERE IDBorrow = @IdBorrow
END
GO

CREATE OR ALTER PROC LoadPurchase
	@IdPurchase INT
AS
BEGIN
	SELECT *
	FROM Purchase
	WHERE IDPurchase = @IdPurchase
END
GO

CREATE OR ALTER PROC LoadBorrow
	@IdBorrow INT
AS
BEGIN
	SELECT *
	FROM BorrowBook
	WHERE IDBorrow = @IdBorrow
END
GO

---------------------------------------------------------Book Return----------------------------------------------

CREATE OR ALTER PROC LoadReturns
AS
BEGIN
	SELECT *
	FROM BorrowBook
	WHERE Returned = 0
END
GO

CREATE OR ALTER PROC LoadReturn
	@IdBorrow INT
AS
BEGIN
	SELECT *
	FROM BorrowBook
	WHERE Returned = 0 AND IDBorrow = @IdBorrow
END
GO

CREATE OR ALTER PROC AddReturn
	@IdBorrow INT,
	@IdBook INT
AS
BEGIN
	UPDATE Book
	SET InStock = InStock + 1
	WHERE IDBook = @IdBook
	UPDATE BorrowBook
	SET Returned = 1
	WHERE IDBorrow = @IdBorrow
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

---------------------------------------------------------Bookstore----------------------------------------------

CREATE OR ALTER PROC LoadBookstore
AS
BEGIN
	SELECT *
	FROM Bookstore
END
GO

CREATE OR ALTER PROC UpdateBookstore
	@IdBookstore INT,
	@Name NVARCHAR(250),
	@Address NVARCHAR(250),
	@IBAN NVARCHAR(250)
AS
BEGIN
	UPDATE Bookstore
	SET Name = @Name,
		Address = @Address,
		IBAN = @IBAN
	WHERE IDBookstore = @IdBookstore
END
GO