CREATE PROCEDURE [dbo].[spEmployee_InsertSet]
	@employees EmployeeSet readonly
AS
begin
	insert into dbo.[Employee] (
	PayrollNumber, 
	Forename, 
	Surname, 
	DateOfBirth, 
	Telephone, 
	Mobile, 
	[Address], 
	Address2, 
	Postcode, 
	EMailHome, 
	StartDate)
	select 
	PayrollNumber, 
	Forename, 
	Surname, 
	DateOfBirth, 
	Telephone, 
	Mobile, 
	[Address], 
	Address2, 
	Postcode, 
	EMailHome, 
	StartDate
	from @employees;
end
