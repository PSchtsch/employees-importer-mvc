using EmployeeDataAccess.DbAccess;
using EmployeeDataAccess.Models;

namespace EmployeeDataAccess.DataAccess;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ISqlDataAccess _db;

    public EmployeeRepository(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
    {
        return _db.LoadDataAsync<EmployeeModel, dynamic>(
            "dbo.spEmployee_GetAll",
            new { });
    }

    public Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(string searchTerm)
    {
        return _db.LoadDataAsync<EmployeeModel, dynamic>(
            "dbo.spEmployee_GetBySearchTerm",
            searchTerm);
    }

    public async Task<EmployeeModel?> GetEmployeeAsync(int id)
    {
        var result = await _db.LoadDataAsync<EmployeeModel, dynamic>(
            "dbo.spEmployee_Get",
            new { Id = id });

        return result.FirstOrDefault();
    }

    public ValueTask<int> InsertEmployeesAsync(IEnumerable<EmployeeModel> employees)
    {
        return _db.SaveDataSetAsync(
            "dbo.spEmployee_InsertSet",
            employees,
            "employees",
            "dbo.EmployeeSet");
    }

    public ValueTask<int> InsertEmployeeAsync(EmployeeModel employee)
    {
        return _db.SaveDataAsync(
            "dbo.spEmployee_Insert",
            employee);
    }

    public ValueTask<int> UpdateEmployeeAsync(EmployeeModel employee)
    {
        return _db.SaveDataAsync(
            "dbo.spEmployee_Update",
            employee);
    }

    public ValueTask<int> DeleteEmployeeAsync(int id)
    {
        return _db.SaveDataAsync(
            "dbo.spEmployee_Delete",
            new { Id = id });
    }
}
