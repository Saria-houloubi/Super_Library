#Created the schema/Database for our super library
#Create schema SuperLibrary;
#The instruction to use a schema / Database
#user schemaName / DatabaseName
#use superlibrary;

#The instruction to drop a table 
#Drop table TableName;
#drop table SuperLibrary.Clinets;

#The instruction to creat a table
#Create Table TableName (
#ColumeName DataType ... not null primary key,
#Colume2Name DataType ... null primary key);

#Create the authoris table
Create Table superlibrary.Authoris(
Id int primary key,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
PhoneNumber nvarchar(20) not null,
Email nvarchar(150) null,
DOB DateTime not null, #mm/dd/yyyy hh:mm:ss tt
Nationalty nvarchar(50) not null	
);
#Create the Books table
Create Table superlibrary.Books(
Id int primary key,
Auther_Id int not null,
Title nvarchar(150) not null,
Description nvarchar(250) null,
Rate int null,
category nvarchar(150) not null,
foreign key(Auther_Id) references superlibrary.Authoris(Id)
);
#Create the Storage table
Create Table SuperLibrary.Storage(
Id int primary key,
Book_Id int not null,
Amount int not null,
LastUpdatedDate DateTime not null,
foreign key Book (Book_Id) references superlibrary.Books(Id)
);
#Create the Clients table
Create Table SuperLibrary.Clients(
Id int primary key,
FirstName nvarchar(50),
LastName nvarchar(50),
PhoneNumber nvarchar(20) not null,
DOB DateTime not null #mm/dd/yyyy hh:mm:ss tt
);
#Create the Reservations table
Create Table SuperLibrary.Reservation(
Id int primary key,
Book_Id int not null,
Clinet_Id int not null,
CreationDate Datetime not null,
EndReservationDate Datetime not null,
PaidAmount double not null,
Note nvarchar(250) null,
foreign key (Book_Id) references superlibrary.Books(Id),
foreign key  (Clinet_Id) references superlibrary.Clients(Id)
);
#Create the Users table table
Create Table SuperLibrary.Users(
Id int primary key,
Username nvarchar(50) not null,
Password nvarchar(50) not null
);



















