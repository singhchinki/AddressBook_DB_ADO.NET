CREATE DATABASE Address_Book_Service_DB

CREATE TABLE AddressBook
(
PersonID varchar(10) not null,
First_Name varchar(20) not null,
Last_Name varChar(20) not null,
Address varchar(100) not null,
City varchar(20) not null,
State varchar(20) not null,
Zip int not null,
Phone_Number varchar(12) not null,
Email varchar(20) not null,
PRIMARY KEY ("PersonID")
);
select * from AddressBook