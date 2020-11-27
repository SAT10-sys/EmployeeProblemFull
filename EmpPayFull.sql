create database EmployeePayrollFull
select * from sys.databases where name='EmployeePayrollFull';
use EmployeePayrollFull

create table EmployeePayroll
(
id int identity(1,1),
name varchar(30) not null,
salary money not null,
startDate date not null,
);
select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='EmployeePayroll';

insert into EmployeePayroll values
('John',500000,'2018-01-13'),
('Paul',600000,'2018-05-09'),
('Roy',650000,'2019-04-15'),
('Ryan',550000,'2017-12-30'),
('David',600000,'2018-01-22');
select * from EmployeePayroll

select salary from EmployeePayroll where name='Paul';
select * from EmployeePayroll where startDate between CAST('2018-12-31' as date) and GETDATE();

alter table EmployeePayroll add gender char(1);
update EmployeePayroll set gender='M' where name='John' or name='Paul' or name='Roy' or name='Ryan' or name='David';
select * from EmployeePayroll

insert into EmployeePayroll values
('Terisa',550000,'2020-05-16','F'),
('Kate',600000,'2019-11-12','F');

select sum(salary) as sum from EmployeePayroll where gender='F' group by gender;

alter table EmployeePayroll add phoneNumber varchar(10);
alter table EmployeePayroll add address varchar(100);
alter table EmployeePayroll add department varchar(20);

update EmployeePayroll set phoneNumber='1111111111', address='Kolkata', department='Engineer' where name='John';
update EmployeePayroll set phoneNumber='2222222222', address='Mumbai', department='Sales' where name='Paul';
update EmployeePayroll set phoneNumber='3333333333', address='Chennai', department='Consultant' where name='Roy';
update EmployeePayroll set phoneNumber='4444444444', address='Bengaluru', department='Engineer' where name='Ryan';
update EmployeePayroll set phoneNumber='5555555555', address='Kolkata', department='Finance' where name='David';
update EmployeePayroll set phoneNumber='6666666666', address='Hyderebad', department='HR' where name='Terisa';
update EmployeePayroll set phoneNumber='7777777777', address='Mumbai', department='Marketing' where name='Kate';
select * from EmployeePayroll

sp_rename 'EmployeePayroll.salary','basicPay';

alter table EmployeePayroll add deductions money, taxablePay money, incomeTax money, netPay money;

update EmployeePayroll set deductions=50000, taxablePay=450000, incomeTax=4500,netPay=445000 where name='John';
update EmployeePayroll set deductions=60000, taxablePay=540000, incomeTax=5400,netPay=534600 where name='Paul';
update EmployeePayroll set deductions=65000, taxablePay=585000, incomeTax=5850,netPay=579150 where name='Roy';
update EmployeePayroll set deductions=55000, taxablePay=495000, incomeTax=4950,netPay=490050 where name='Ryan';
update EmployeePayroll set deductions=60000, taxablePay=540000, incomeTax=5400,netPay=534600 where name='David';
update EmployeePayroll set deductions=55000, taxablePay=495000, incomeTax=4950,netPay=490050 where name='Terisa';
update EmployeePayroll set deductions=60000, taxablePay=540000, incomeTax=5400,netPay=534600 where name='Kate';


/* ERDIAGRAM */

create table Employee
(
EId int identity(1,1) primary key not null,
Ename varchar(30) not null,
Gender char(1) not null,
PhoneNumber varchar(10) not null,
Address varchar(100) not null,
StartDate date not null,
);
insert into Employee values
('John','M','1111111111','Kolkata','2018-01-13'),
('Paul','M','2222222222','Mumbai','2018-05-09'),
('Roy','M','3333333333','Chennai','2019-04-15'),
('Ryan','M','4444444444','Bengaluru','2017-12-30'),
('David','M','5555555555','Kolkata','2018-01-22'),
('Terisa','F','6666666666','Hyderebad','2020-05-16'),
('Kate','F','7777777777','Mumbai','2019-11-12');
select * from Employee


create table Department
(
DeptId varchar(5) primary key not null,
DeptName varchar(20) not null,
);
insert into Department values
('D01','Engineer'),
('D02','Sales'),
('D03','Consultant'),
('D04','Finance'),
('D05','HR'),
('D06','Marketing'),
('D07','Testing');
select * from Department

create table Employee_Department
(
EmpId int foreign key references Employee(EId),
DeptId varchar(5) foreign key references Department(DeptId),
);
insert into Employee_Department values
(1,'D01'),(2,'D02'),(3,'D03'),(4,'D01'),(5,'D04'),(6,'D05'),(7,'D06');
select * from Employee_Department

create table EmpPayroll
(
Eid int foreign key references Employee(Eid),
BasicPay money not null,
Deductions money not null,
TaxablePay money not null,
IncomeTax money not null,
NetPay money not null,
);
insert into EmpPayroll values
(1,500000,50000,450000,4500,445000),
(2,6000000,60000,540000,5400,534600),
(3,650000,65000,585000,5850,579150),
(4,550000,55000,495000,4950,490050),
(5,600000,60000,540000,5400,534600),
(6,550000,55000,495000,4950,490050),
(7,600000,60000,540000,5400,534600);
select * from EmpPayroll

select Gender, SUM(BasicPay) as sum, AVG(BasicPay) as avg, Min(BasicPay) as min, MAX(BasicPay) as max from Employee inner join EmpPayroll on Employee.EId=EmpPayroll.Eid group by Gender;
select BasicPay from EmpPayroll inner join Employee on  EmpPayroll.EId=Employee.EId where EName='Paul';

select Employee.EId, EName, BasicPay, DeptName from Employee 
inner join Employee_Department on Employee.EId=Employee_Department.EmpId
inner join EmpPayroll on Employee.EId=EmpPayroll.Eid
inner join Department on Department.DeptId=Employee_Department.DeptId;