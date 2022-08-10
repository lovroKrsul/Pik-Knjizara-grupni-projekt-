USE [master]
GO
DROP DATABASE IF EXISTS [PraKnjizara]
GO
CREATE DATABASE [PraKnjizara]
GO
USE [PraKnjizara]

---------------------------------------------------------Tables----------------------------------------------

CREATE TABLE Author(
	[IDAuthor] [int] PRIMARY KEY IDENTITY,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Biography] [nvarchar](max) NULL,
	[DeletedAt] [datetime] NULL
)

CREATE TABLE Person(
	IDUser int PRIMARY KEY IDENTITY,
	FirstName nvarchar(250) NOT NULL,
	LastName nvarchar(250) NOT NULL,
	Email nvarchar(250) NOT NULL,
	Password nvarchar(250) NOT NULL,
	City nvarchar(250) NULL,
	ZipCode nvarchar(250) NULL,
	StreetName nvarchar(250) NULL,
	PersonCode nvarchar(250) NULL,
	StreetNumber nvarchar(250) NULL,
	OIB nvarchar(250) NULL,
	Workplace nvarchar(250) NULL,
	DeletedAt datetime NULL
)

CREATE TABLE [dbo].[Delay](
	[IDDelay] [int] PRIMARY KEY IDENTITY,
	[DelayInDays] [int] NULL,
	[DelayPrice] [int] NULL,
	[DeletedAt] [datetime] NULL
)

CREATE TABLE Book(
	IDBook int PRIMARY KEY IDENTITY,
	Title nvarchar(250) NOT NULL,
	AuthorID int FOREIGN KEY REFERENCES [Author] (IDAuthor),
	Description nvarchar(max) NULL,
	ISBN NVARCHAR(50) NOT NULL,
	Used BIT NOT NULL,
	InStock INT NOT NULL,
	Price MONEY NOT NULL,
	Cover nvarchar(MAX) NULL,
	Publisher nvarchar(250) NULL,
	Ganre nvarchar(250) NULL,
	Tags nvarchar(max) NULL,
	ReleseYear datetime NULL,
	DeletedAt datetime NULL
)

CREATE TABLE [dbo].[BookLend](
	[IDLend] [int] PRIMARY KEY IDENTITY,
	[PersonID] [int] FOREIGN KEY REFERENCES [Person] (IDUser),
	[BookID] [int] FOREIGN KEY REFERENCES [Book] (IDBook),
	[DelayID] [int] FOREIGN KEY REFERENCES [Delay] (IDDelay),
	[ReturnDate] [datetime] NULL,
	[Bookstate] [nvarchar](50) NULL,
	[PaypalPayment] [nvarchar](50) NULL,
	[LibraryPayment] [nvarchar](50) NULL,
	[DeletedAt] [datetime] NULL
)

CREATE TABLE [dbo].[Bookstore](
	[IDBookstore] [int] PRIMARY KEY IDENTITY,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[IBAN] [nvarchar](100) NULL,
	[Logo] [nvarchar](100) NULL,
	[DeletedAt] [datetime] NULL
)

CREATE TABLE [dbo].[BookstoreEmployees](
	[IDbookstoreEmployee] [int] PRIMARY KEY IDENTITY,
	[EmployeeID] [int] FOREIGN KEY REFERENCES [Person] (IDUser),
	[BookstoreID] [int] FOREIGN KEY REFERENCES [Bookstore] (IDBookstore)
)

CREATE TABLE [dbo].[Purchase](
	[IDPurchase] [int] PRIMARY KEY IDENTITY,
	[PurchaseDate] [datetime] NULL,
	[PaypalPayment] [nvarchar](50) NULL,
	[LibraryPayment] [nvarchar](50) NULL,
	[Delivery] [nvarchar](50) NULL,
	[PersonID] [int] FOREIGN KEY REFERENCES [Person] (IDUser),
	[BookID] [int] FOREIGN KEY REFERENCES [Book] (IDBook),
	[DeletedAt] [datetime] NULL
)

GO

/*
 create OR ALTER proc [dbo].[AddAuthor]
 @FirstName nvarchar(50),
@LastName nvarchar(50),
@Description nvarchar(max),
@Biography nvarchar(max)
as
insert into Author(FirstName,LastName,Description,Biography) values (@FirstName,@LastName,@Description,@Biography)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROC [dbo].[AddBook]
@Title nvarchar(50),
@Cover nvarchar(50),
@AuthorID int,
@ISBN int,
@PurchasePrice int,
@LendPrice int,
@Avalability nvarchar(20),
@BookDesription nvarchar(max),
@Publiher nvarchar(50),
@ReleseYear datetime,
@ganre nvarchar(50),
@category nvarchar(50),
@tags nvarchar(max),
@Bookstate nvarchar(50)
as 
GO


CREATE OR ALTER PROC [dbo].[AddBookLend]
@PersonID int,
@BookID int,
@DelayID int,
@ReturnDate datetime,
@Bookstate nvarchar(50),
@PaypalPayment nvarchar(50),
@LibraryPayment nvarchar(50)
as
insert into BookLend(PersonID,BookID,DelayID,ReturnDate,Bookstate,PaypalPayment,LibraryPayment) values  (@PersonID,@BookID,@DelayID,@ReturnDate,@Bookstate,@PaypalPayment,@LibraryPayment)
GO


CREATE OR ALTER PROC [dbo].[AddBookstore]
@Name nvarchar(50),
@Address nvarchar(100),
@IBAN nvarchar(100),
@Logo nvarchar(100)
as
 insert into bookstore (Name,Address,IBAN,Logo) values (@Name,@Address,@IBAN,@Logo)
GO


CREATE OR ALTER PROC [dbo].[AddDelay]
@DelayInDays int,
@DelayPrice int

as
insert into delay(DelayInDays,DelayPrice) values (@DelayInDays,@DelayPrice)
GO


 CREATE OR ALTER PROC [dbo].[AddEmployee]
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Email nvarchar(50),
@Password nvarchar(50),
@Accept bit,
@OIB nvarchar(50),
@Workplace nvarchar(50)
 as
 insert into Employee(FirstName,LastName,Email,Password,Accept,OIB,Workplace) values (@FirstName,@LastName,@Email,@Password,@Accept,@OIB,@Workplace)
GO


CREATE OR ALTER PROC [dbo].[AddPurchase]
@PurchaseDate datetime,
@PaypalPayment nvarchar(50),
@LibraryPayment nvarchar(50),
@Delivery nvarchar(50),
@PersonID int,
@BookID int
as
insert into Purchase(PurchaseDate,PaypalPayment,LibraryPayment,Delivery,PersonID,BookID) values (@PurchaseDate,@PaypalPayment,@LibraryPayment,@Delivery,@PersonID,@BookID)
GO


CREATE OR ALTER PROC [dbo].[AddPerson]
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Email nvarchar(50),
@Password nvarchar(50),
@City nvarchar(50),
@ZipCode nvarchar(50),
@Address nvarchar(50),
@PersonCode nvarchar(50),
@StreetNumber nvarchar(50)
as
insert into Person(FirstName,LastName,Email,Password,City,ZipCode,Address,PersonCode,StreetNumber) values (@FirstName,@LastName,@Email,@Password,@City,@ZipCode,@Address,@PersonCode,@StreetNumber)
GO


CREATE OR ALTER PROC [dbo].[DeleteAuthor]
@ID int
as
update Author Set DeletedAt=GETDATE() where Author.IDAuthor=@ID
GO


CREATE OR ALTER PROC [dbo].[DeleteBook]
@ID int
as
update book set DeletedAt=GETDATE() where book.IDBook=@ID
GO


CREATE OR ALTER PROC [dbo].[DeleteBookLend]
@ID int
as
update BookLend set DeletedAt=Getdate() where BookLend.IDLend=@ID
GO


 CREATE OR ALTER PROC [dbo].[DeleteBookstore]
 @ID int
 as
 update bookstore set DeletedAt=GETDATE() where bookstore.IDBookstore=@ID
GO


CREATE OR ALTER PROC [dbo].[DeleteDelay]
@ID int
as
update delay set DeletedAt=GETDATE() where IDDelay=@ID
GO


CREATE OR ALTER PROC [dbo].[DeleteEmployee]
@ID int
 as
 update Employee set DeletedAt=GETDATE() where Employee.IDEmployee=@ID
GO


CREATE OR ALTER PROC [dbo].[DeletePurchase]
@ID int
as
update Purchase set DeletedAt=GETDATE() where Purchase.IDPurchase=@ID
GO


CREATE OR ALTER PROC [dbo].[DeletePerson]
@ID int
as
update Person set DeletedAt=GETDATE() where Person.IDUser=@ID
GO


CREATE OR ALTER PROC [dbo].[LoadAuthors]
as
select* from Author where DeletedAt is null
GO


CREATE OR ALTER PROC [dbo].[LoadAuthorsByID]
@ID int
as
select * from Author where DeletedAt is null and IDAuthor=@ID
GO


CREATE OR ALTER PROC [dbo].[LoadBookLends]
as
select* from BookLend where DeletedAt is null
GO


CREATE OR ALTER PROC [dbo].[LoadBookLendsByID]
@ID int
as
select* from BookLend where DeletedAt is null and BookLend.IDLend=@ID
GO


CREATE OR ALTER PROC [dbo].[LoadBooks] 
as
select* from book where DeletedAt is null
GO


CREATE OR ALTER PROC [dbo].[LoadBooksByID]
@ID int
as
select * from book where DeletedAt is null and IDBook=@ID
GO


CREATE OR ALTER PROC [dbo].[LoadBookstores] 
as
select* from bookstore where DeletedAt is null
GO


CREATE OR ALTER PROC [dbo].[LoadBookstoresByID]
@ID int
as
select * from bookstore where DeletedAt is null and IDBookstore=@ID
GO


CREATE OR ALTER PROC [dbo].[LoadPersons]
as
select * from Person where DeletedAt is null
GO


CREATE OR ALTER PROC [dbo].[LoadPersonsByID]
@ID int
as
select * from Person where DeletedAt is null and Person.IDUser=@ID
GO


CREATE OR ALTER PROC [dbo].[LoadDelays]
as
select* from delay where DeletedAt is null
GO


CREATE OR ALTER PROC [dbo].[LoadDelaysByID]
@ID int
as
select* from delay where DeletedAt is null and IDDelay=@ID
GO


CREATE OR ALTER PROC [dbo].[LoadEmployees] 
as
select* from Employee where DeletedAt is null 
GO


CREATE OR ALTER PROC [dbo].[LoadEmployeesByID]
@ID int
as
select* from Employee where DeletedAt is null and IDEmployee=@ID
GO


CREATE OR ALTER PROC [dbo].[LoadPurchases]
as
select * from Purchase where DeletedAt is null
GO


CREATE OR ALTER PROC [dbo].[LoadPurchasesByID]
@ID int
as
select * from Purchase where DeletedAt is null and Purchase.IDPurchase=@ID
GO


CREATE OR ALTER PROC [dbo].[UpdateBook]
@ID int,
@Title nvarchar(50),
@Cover nvarchar(50),
@AuthorID int,

@ISBN int,
@PurchasePrice int,
@LendPrice int,
@Avalability nvarchar(20),
@BookDesription nvarchar(max),
@Publiher nvarchar(50),
@ReleseYear datetime,
@ganre nvarchar(50),
@category nvarchar(50),
@tags nvarchar(max),
@Bookstate nvarchar(50)
as
begin
update book set Title=@Title where IDBook=@ID
update book set Cover=@Cover where IDBook=@ID
update book set AuthorID=@AuthorID where IDBook=@ID
update book set ISBN=@ISBN where IDBook=@ID
update book set PurchasePrice=@PurchasePrice where IDBook=@ID
update book set LendPrice=@LendPrice where IDBook=@ID
update book set Avalability=@Avalability where IDBook=@ID
update book set BookDesription=@BookDesription where IDBook=@ID
update book set Publiher=@Publiher where IDBook=@ID
update book set ReleseYear=@ReleseYear where IDBook=@ID
update book set ganre=@ganre where IDBook=@ID
update book set category=@category where IDBook=@ID
update book set tags=@tags where IDBook=@ID
update book set Bookstate=@Bookstate where IDBook=@ID

end
GO


CREATE OR ALTER PROC [dbo].[UpdateBookLend]
@ID int,
@PersonID int,
@BookID int,
@DelayID int,
@ReturnDate datetime,
@Bookstate nvarchar(50),
@PaypalPayment nvarchar(50),
@LibraryPayment nvarchar(50)
as

begin
update BookLend set PersonID=@PersonID where BookLend.IDLend=@ID
update BookLend set BookID=@BookID where BookLend.IDLend=@ID
update BookLend set DelayID=@DelayID where BookLend.IDLend=@ID
update BookLend set ReturnDate=@ReturnDate where BookLend.IDLend=@ID
update BookLend set Bookstate=@Bookstate where BookLend.IDLend=@ID
update BookLend set PaypalPayment=@PaypalPayment where BookLend.IDLend=@ID
update BookLend set LibraryPayment=@LibraryPayment where BookLend.IDLend=@ID
end
GO


 CREATE OR ALTER PROC [dbo].[UpdateBookstore]
 @ID int,
 @Name nvarchar(50),
 @Address nvarchar(100),
@IBAN nvarchar(100),
@Logo nvarchar(100)
 as
 begin
  update bookstore set Name=@Name where IDBookstore=@ID
   update bookstore set Address=@Address where IDBookstore=@ID
    update bookstore set IBAN=@IBAN where IDBookstore=@ID
	 update bookstore set Logo=@Logo where IDBookstore=@ID

 end
GO


CREATE OR ALTER PROC [dbo].[UpdateDelay]
@ID int,
@DelayInDays int,
@DelayPrice int
as
begin
update delay set DelayInDays=@DelayInDays where delay.IDDelay=@ID
update delay set DelayPrice=@DelayPrice where delay.IDDelay=@ID

end
GO


  CREATE OR ALTER PROC [dbo].[UpdateEmployee]
@ID int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Email nvarchar(50),
@Password nvarchar(50),
@Accept bit,
@OIB nvarchar(50),
@Workplace nvarchar(50)
 as
 begin
  update Employee set FirstName=@FirstName where IDEmployee=@ID
  update Employee set LastName=@LastName where IDEmployee=@ID
   update Employee set Email=@Email where IDEmployee=@ID
    update Employee set Password=@Password where IDEmployee=@ID
	 update Employee set Accept=@Accept where IDEmployee=@ID
	  update Employee set OIB=@OIB where IDEmployee=@ID
	   update Employee set Workplace=@Workplace where IDEmployee=@ID
   

 end
GO


CREATE OR ALTER PROC [dbo].[UpdatePurchase]
@ID int,
@PurchaseDate datetime,
@PaypalPayment nvarchar(50),
@LibraryPayment nvarchar(50),
@Delivery nvarchar(50),
@PersonID int,
@BookID int
as
begin
update Purchase set PurchaseDate=@PurchaseDate where Purchase.IDPurchase=@ID
update Purchase set PaypalPayment=@PaypalPayment where Purchase.IDPurchase=@ID
update Purchase set LibraryPayment=@LibraryPayment where Purchase.IDPurchase=@ID
update Purchase set Delivery=@Delivery where Purchase.IDPurchase=@ID
update Purchase set PersonID=@PersonID where Purchase.IDPurchase=@ID
update Purchase set BookID=@BookID where Purchase.IDPurchase=@ID
end
GO


CREATE OR ALTER PROC [dbo].[UpdatePerson]
@ID int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Email nvarchar(50),
@Password nvarchar(50),
@City nvarchar(50),
@ZipCode nvarchar(50),
@Address nvarchar(50),
@PersonCode nvarchar(50),
@StreetNumber nvarchar(50)
as 
begin
update Person set FirstName=@FirstName where Person.IDUser=@ID
update Person set LastName=@LastName where Person.IDUser=@ID
update Person set Email=@Email where Person.IDUser=@ID
update Person set Password=@Password where Person.IDUser=@ID
update Person set ZipCode=@ZipCode where Person.IDUser=@ID
update Person set Address=@Address where Person.IDUser=@ID
update Person set PersonCode=@PersonCode where Person.IDUser=@ID
update Person set StreetNumber=@StreetNumber where Person.IDUser=@ID
end
GO
*/