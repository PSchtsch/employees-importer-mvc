CREATE PROCEDURE [dbo].[spEmployee_Get]
	@Id int
AS
begin
	select *
	from dbo.[Employee]
	where Id = @Id;
end
