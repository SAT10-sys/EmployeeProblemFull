go
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
@StartDate date,
@EmpId int out
)
as
begin
set XACT_ABORT on;
begin try;
begin transaction;
insert into Employee values
(
@EmployeeName, @Gender, @PhoneNumber, @Address, @StartDate
)
set @EmpId=SCOPE_IDENTITY();
insert into EmpPayroll values
(
@EmpId, @BasicPay, @Deductions, @TaxableIncome, @IncomeTax, @NetPay
)
insert into Employee_Department values
(
@EmpId, (select DeptId from Department where DeptName=@Department)
)
commit transaction;
end try
begin catch
select ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() AS ErrorMessage;
IF(XACT_STATE())=-1
BEGIN
  PRINT N'The transaction is in an uncommitable state.'+'Rolling back transaction.'
  ROLLBACK TRANSACTION;
  END;

  IF(XACT_STATE())=1
  BEGIN
    PRINT 
	    N'The transaction is committable. '+'Committing transaction.'
       COMMIT TRANSACTION;
	END;
	END CATCH
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

