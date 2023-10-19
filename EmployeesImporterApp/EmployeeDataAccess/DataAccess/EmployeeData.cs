using EmployeeDataAccess.DbAccess;
using EmployeeDataAccess.Models;

namespace EmployeeDataAccess.DataAccess;

//TODO: extract interface
public class EmployeeData
{
    private readonly ISqlDataAccess _db;

    public EmployeeData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
    {
        return _db.LoadDataAsync<EmployeeModel, dynamic>(
            "dbo.spEmployee_GetAll",
            new { });
    }

    //for searching
    public Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(string employeeName)
    {
        //add local method for name/fullname, new sp
        throw new NotImplementedException();
    }

    public async Task<EmployeeModel?> GetEmployeeAsync(int id)
    {
        var result = await _db.LoadDataAsync<EmployeeModel, dynamic>(
            "dbo.spEmployee_Get",
            new { Id = id });

        return result.FirstOrDefault();
    }

    //insert employees or both options
    public ValueTask<int> InsertEmployeeAsync(EmployeeModel employee)
    {
        // need to insert set of employees not just one. udt makes sense here mb
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
