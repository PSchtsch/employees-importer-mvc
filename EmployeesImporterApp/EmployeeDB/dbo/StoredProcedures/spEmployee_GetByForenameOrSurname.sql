CREATE PROCEDURE [dbo].[spEmployee_GetByForenameOrSurname]
	@ForenameOrSurname nvarchar(50)
AS
begin
	select *
	from dbo.[Employee]
	where Forename = @ForenameOrSurname or Surname = @ForenameOrSurname;
end
