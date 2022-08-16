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
	CreatedAt DATETIME NOT NULL,
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
	CreatedAt DATETIME NOT NULL,
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
