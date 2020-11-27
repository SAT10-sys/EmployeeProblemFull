create procedure SpAddEmployeeDetails
(
@EmployeeName varchar(30),
@PhoneNumber varchar(10),
@Address varchar(100),
@Department varchar(20),
@Gender char(1),
@BasicPay float,
@Deductions float,
@TaxableIncome float,
@IncomeTax float,
@NetPay float,
@StartDate date
)
as
begin
insert into EmployeePayroll values
(
@EmployeeName, @BasicPay, @StartDate, @Gender, @PhoneNumber, @Address, @Department, @Deductions, @TaxableIncome, @IncomeTax, @NetPay
)
end


go
create procedure GetEmployeesInDateRange
(
@StartDate1 date,
@StartDate2 date
)
as 
begin
select id, name, basicPay, startDate, gender, phoneNumber, address, department, deductions, taxablePay, incometax, netPay from EmployeePayroll where startDate between @StartDate1 and @StartDate2;
end

