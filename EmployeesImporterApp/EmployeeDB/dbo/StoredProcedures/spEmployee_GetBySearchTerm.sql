CREATE PROCEDURE [dbo].[spEmployee_GetBySearchTerm]
	@searchTerm nvarchar(50)
AS
begin
	select *
	from dbo.[Employee]
	where Forename like '%' + @searchTerm + '%'
		or Surname like '%' + @searchTerm + '%';
end
