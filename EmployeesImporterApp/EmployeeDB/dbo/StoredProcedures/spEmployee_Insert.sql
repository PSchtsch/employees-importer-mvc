CREATE PROCEDURE [dbo].[spEmployee_Insert]
	@PayrollNumber nvarchar(50),
	@Forename nvarchar(50),
	@Surname nvarchar(50),
	@DateOfBirth date,
	@Telephone varchar(15),
	@Mobile varchar(15),
	@Address nvarchar(150),
	@Address2 nvarchar(150),
	@Postcode varchar(15),
	@EMailHome nvarchar(320),
	@StartDate date
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
	values(
	@PayrollNumber, 
	@Forename, 
	@Surname, 
	@DateOfBirth, 
	@Telephone, 
	@Mobile, 
	@Address, 
	@Address2, 
	@Postcode, 
	@EMailHome, 
	@StartDate);
end
