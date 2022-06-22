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
insert into AddressBook (PersonID,First_Name,Last_Name,Address,City,State,Zip,Phone_Number,Email) 
values('SurajDal','Suraj','Dal','Rajgad','Pune','Maharashtra','412213','9876543210','surajdal@gmail.com');
insert into AddressBook (PersonID,First_Name,Last_Name,Address,City,State,Zip,Phone_Number,Email) 
values('SanketDal','Sanket','Dal','Vadgaon','Pune','Maharashtra','411047','9423371234','sanketdal@gmail.com');
insert into AddressBook (PersonID,First_Name,Last_Name,Address,City,State,Zip,Phone_Number,Email) 
values('MayureshD','Mayuresh','D','Marathahalli','Bangalore','Karnataka','560037','9906607712','mayuresh@gmail.com');
insert into AddressBook (PersonID,First_Name,Last_Name,Address,City,State,Zip,Phone_Number,Email) 
values('AdityaT','Aditya','T','Juhu','Mumbai','Maharashtra','400001','9867542310','adityat@gmail.com');
insert into AddressBook (PersonID,First_Name,Last_Name,Address,City,State,Zip,Phone_Number,Email) 
values('AkshayP','Akshay','P','Narhe','Pune','Maharashtra','4110047','9988776655','pakshay@gmail.com');
select * from AddressBook;

--update table
update AddressBook set Phone_Number='9049091234' where PersonID='SurajDal';
select * from AddressBook;

--delete entries from table
delete from AddressBook where PersonID='SanketDal';
select * from AddressBook;

--retrieve by city or state
select * from AddressBook where City='Pune';
select * from AddressBook where State='Karnataka';

--counts by city or state
select COUNT(city) from AddressBook;
select City, count(*) as AddressCount
from AddressBook group by (City);

select COUNT(State) from AddressBook;
select State, count(*) as AddressCount
from AddressBook group by (State);
select * from AddressBook where City = 'Pune'
order by (First_Name);

--alter table to add name and type of contact
alter table AddressBook add Name varchar(300) not null,Type varchar(300) not null;
select * from AddressBook;

update AddressBook set Name='IT', Type='Profession' where PersonID='MayureshD';
update AddressBook set Name='Self', Type='Self' where PersonID='SurajDal';
update AddressBook set Name='School', Type='Friend' where PersonID='AkshayP';
update AddressBook set Name='Diploma', Type='Friend' where PersonID='AdityaT';
select * from AddressBook;

select COUNT(State) from AddressBook;
select Type, count(*) as NoOfContacts
from AddressBook group by (Type);

--add person to both family and friend
insert into AddressBook (PersonID,First_Name,Last_Name,Address,City,State,Zip,Phone_Number,Email,Name,Type)
values('Akash','Akash','D','Rajgad','Pune','Maharashtra','412213','9876554631','dakash@gmail.com','Brother','Family');
insert into AddressBook (PersonID,First_Name,Last_Name,Address,City,State,Zip,Phone_Number,Email,Name,Type)
values('Saket','Saket','V','Marathahalli','Bangalore','Karnataka','560037','9823432123','saket@gmail.com','Degree','Friend');

alter table AddressBook add PersonID int identity not null primary key; 

--UC12 Draw ER diag for Address book DB
create table ContactType(
Type_ID int identity Primary key,
Type_Name varchar(50) not null
);
insert into ContactType values('Family'),('Friend'),('Colleagues');
select * from ContactType;

Create table Person_Address(
Contact_ID int identity primary key not null,
F_Name varchar(30) not null,
L_Name varchar(30) not null,
City varchar (30) not null,
State varchar (30) not null,
Zip int not null,
Email varchar(50) not null
);

insert into Person_Address values('Suraj','Dal','Pune','Maharashtra','411213','surajdal@gmail.com');
insert into Person_Address values('Sanket','Dal','Pune','Maharashtra','411213','sanketdal@gmail.com');
insert into Person_Address values('Mayuresh','D','Nashik','Maharashtra','423003','mayureshd@gmail.com');
insert into Person_Address values('Aditya','T','Mumbai','Maharashtra','400001','adityat@gmail.com');

select * from Person_Address;

--Adding constraints to tables
alter table Person_Address add constraint fk_ContactType foreign key(Contact_ID) references ContactType(Type_ID);
alter table Address_Book add constraint fk_Person_Address foreign key(PersonID) references Person_Address(Contact_Type);

select * from AddressBook where City='Pune';
select * from AddressBook where State='Karnataka';

select COUNT(State) from AddressBook;
select Type, count(*) as NoOfContacts
from AddressBook group by (Type);
