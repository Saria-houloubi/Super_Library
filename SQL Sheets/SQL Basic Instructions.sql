#Select (ColumnsName1,ColumnName2...) From TableName;#
#Select * From TableName;
#Gets all the tables in the schema /Database
show tables from superLibrary;
#selects all the data from the authoris table
Select * From superlibrary.authoris;
#Select all the data from the books table
Select * From superlibrary.Books;
#Conditional Select
Select * from superlibrary.authoris 
Where Id <= 4 Or firstName= "Mohammad";
#Select Selective columns
Select concat(firstName,' ',LastName) As FullName, Email As MyEmail from superlibrary.authoris
Where Id <= 4 And firstName= "Mohammad";
#Orderd Select
Select FirstName, Id from superlibrary.authoris
order by Id ;

Select FirstName, Id from superlibrary.authoris
order by Id desc;

select * from superlibrary.authoris 
where FirstName Like "%M%";
#Select only one value
Select * From superlibrary.authoris
Where id = 2;
#-----------------------------------------------------------------
#Insert into tableName (ColumnName1,ColumnName2,..)
#Values
#(Value1,Value2,...);
#get all the columns in the authoris table
show columns from superlibrary.authoris;
#Insert a value
insert into superlibrary.authoris (FirstName,LastName,PhoneNumber,Email,DOB,Nationalty)
Values
("Mohammad","Saria","123456","MyEmail@email.com",'1996-4-11',"Syrian");
#Try to insert a null value
insert into superlibrary.authoris (FirstName,LastName,PhoneNumber,DOB,Nationalty)
Values
("Mohammad","SomeLastName","123456",'1996-4-11 11:18:00',"Syrian");
#-----------------------------------------------------------------
#Update
#UPDATE TabeName SET ColumnName = Value Where Condition;
UPDATE superlibrary.authoris SET PhoneNumber = "123"
 WHERE id = 2;
Update superlibrary.authoris SET email ="MyNewEmail@Email.com"
where id = 5;
Update superlibrary.authoris SET email = null
Where Id > 5;
#-----------------------------------------------------------------
#Delete 
#Delete from TabelName Where Condition
Delete From superlibrary.authoris where id = 1;
