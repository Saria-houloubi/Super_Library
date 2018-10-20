Show Tables from superlibrary;
#Show Table Infomration
SHOW COLUMNS FROM superlibrary.authoris;
SHOW COLUMNS FROM superlibrary.Books;

#Select
#General Form : SELECT  Colunm1,Colunm2,Colunm3... FROM TableName;
# * All columns
#Select * FROM TableName
#Selects all columns from the table
SELECT * FROM superlibrary.authoris;
#Selec spacific columns
SELECT FirstName,LastName,DOB FROM	superlibrary.authoris;
#Using as
SELECT concat(FirstName,' ',LastName) AS Full_Name ,DOB AS Date_Of_Birth FROM superlibrary.authoris;
#Where select
SELECT * FROM superlibrary.authoris 
WHERE Id = 2 OR firstName = "Auto";
#Select All books
SELECT * FROM superlibrary.books;
#Get information from multiple tables
SELECT auth.FirstName, auth.LastName, book.Title
FROM superlibrary.authoris AS auth ,superlibrary.books AS book
WHERE book.Auther_Id = auth.id;
#Order Data
SELECT * FROM superlibrary.authoris
ORDER BY FirstName;

#Insert
#General Form : INSERT INTO TableName (Column1,Column2,...)
#				VALUES
#				(Value1,Value2,...);
#DataTime Format yyyy-MM-dd HH:mm:ss
INSERT INTO superlibrary.authoris (Id,FirstName,LastName,PhoneNumber,Email,DOB,Nationalty)
VALUES
(1,"Saria","Houloubi","0000","MyEmail@Email.com",'1996-11-4',"Syrian");
#Auto incremented
INSERT INTO superlibrary.authoris (FirstName,LastName,PhoneNumber,Email,DOB,Nationalty)
VALUES
("Auto","Incremented","0000","MyEmail@Email.com",'1996-11-4',"Syrian");
#No Email provided
INSERT INTO superlibrary.authoris (FirstName,LastName,PhoneNumber,DOB,Nationalty)
VALUES
("Auto","Incremented","0000",'1996-11-4',"Syrian");
INSERT INTO superlibrary.books (auther_Id,Title,Description,Rate,Category)
VALUES
(2,"Super Book","Our first book",5,"Comedy");

#Update 
#General Form : UPDATE TableName SET ColumnName = Value1,ColumnName2 = Value2... 
#				WHERE Condition;
UPDATE superlibrary.authoris SET Email = "GotMyEmail@Email.com"
WHERE id = 4;
UPDATE superlibrary.authoris SET PhoneNumber = "Same Phone";

#Delete
#General Form : DELETE FROM TableName WHERE Condition
DELETE FROM superlibrary.authoris WHERE id =1;
