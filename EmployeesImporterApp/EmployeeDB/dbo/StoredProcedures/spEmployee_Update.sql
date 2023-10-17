CREATE PROCEDURE [dbo].[spEmployee_Update]
	@Id int,
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
	update dbo.[Employee]
	set 
	PayrollNumber = @PayrollNumber, 
	Forename = @Forename, 
	Surname = @Surname, 
	DateOfBirth = @DateOfBirth, 
	Telephone = @Telephone, 
	Mobile = @Mobile, 
	[Address] = @Address, 
	Address2 = @Address2, 
	Postcode = @Postcode, 
	EMailHome = @EMailHome, 
	StartDate = @StartDate
	where Id = @Id;
end
