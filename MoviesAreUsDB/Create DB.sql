/*
Use Master
GO
Drop Database MoviesAreUsDB
GO

USE MoviesAreUsDB
DELETE FROM Orders
DELETE FROM Food
SELECT * FROM Orders
Select * FROM Food
*/
   
CREATE DATABASE MoviesAreUsDB  
ON (NAME = 'MoviesAreUsDB', 
    FILENAME = 'D:\MoviesAreUsDB\MoviesAreUsDB_Data.MDF' , 
    SIZE = 10, 
    FILEGROWTH = 10%) 
LOG ON (NAME = 'MoviesAreUsDB_Log', 
        FILENAME = 'D:\MoviesAreUsDB\MoviesAreUsDB_Log.LDF' ,
        SIZE = 5, 
        FILEGROWTH = 10%)
COLLATE Hebrew_CI_AS
GO

Use MoviesAreUsDB 
GO

-- הגדרת טבלאות
CREATE TABLE [Films] (
	[Id] [smallint] IDENTITY(1,1)  NOT NULL  ,
	[Title] nvarchar (30) ,
	[Plot] nvarchar (300),
	[Poster] nvarchar (20)	 	  
)
GO

CREATE TABLE [Users] (
	[Id] [smallint] IDENTITY(1,1) NOT NULL ,
	[Username] nvarchar (20),
	[Password] nvarchar (20) 	 	  
)
GO

CREATE TABLE [Food] (
	[Id] [smallint] IDENTITY(1,1) NOT NULL  ,
	[FoodId] [smallint] NOT NULL,
	[OrderId] [smallint] NOT NULL,
	[OrderQuantity] nvarchar(30)
	 	  
)
GO

CREATE TABLE [Orders] (
	[Id] [smallint] IDENTITY(1,1) NOT NULL  ,
	[FilmId] [smallint] NOT NULL,
	[UserId] [smallint] NOT NULL,
	[Seats] nvarchar(150),
	[Payment] nvarchar(20),
	[DateNTime] nvarchar(50)
	 	  
)
GO
--הגדרת מפתחות ראשיים
ALTER TABLE Films 
ADD
CONSTRAINT [PK_Films] PRIMARY KEY (Id)
GO

ALTER TABLE Users 
ADD
CONSTRAINT [PK_Users] PRIMARY KEY (Id)
GO

ALTER TABLE Orders 
ADD
CONSTRAINT [PK_Orders] PRIMARY KEY (Id)
GO

ALTER TABLE Food 
ADD
CONSTRAINT [PK_Food] PRIMARY KEY (Id)
GO
--הגדרת מפתחות משניים
--ALTER TABLE Orders
--ADD
--CONSTRAINT [Con_fk_Food_Order_Id] FOREIGN KEY 
--         (FoodOrderId) REFERENCES Food (Id)
--go
--הזנת ערכים טבלת קטגוריות
Insert dbo.Films (Title,Plot,Poster) Values ('Matrix','Matrix depicts a dystopia future in which reality 
as perceived by most humans is actually a simulated reality called "the Matrix", created by sentient
machines to subdue the human population, while their bodies heat and electrical activity are used as 
an energy source.','matrix.jpg')
Insert dbo.Films (Title,Plot,Poster) Values ('Fight Club','An insomniac office worker, looking for a way
 to change his life, crosses paths with a devil-may-care soap maker, forming an undergroundfight club
  that evolves into something much, much more.','fightclub.jpg')
Insert dbo.Films (Title,Plot,Poster) Values ('The Shawshank Redemption','Two imprisoned men bond over a 
number of years, finding solace and eventual redemption through acts of common decency.','shawshank.jpg')

go

Insert dbo.Users (Username,Password) Values ('ADMIN','ADMIN')
 go
Insert dbo.Users (Username,Password) Values ('Avi','2601')
 go

 