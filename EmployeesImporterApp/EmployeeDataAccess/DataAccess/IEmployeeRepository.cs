using EmployeeDataAccess.Models;

namespace EmployeeDataAccess.DataAccess;

public interface IEmployeeRepository
{
    ValueTask<int> DeleteEmployeeAsync(int id);
    Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
    Task<EmployeeModel?> GetEmployeeAsync(int id);
    Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(string searchTerm);
    ValueTask<int> InsertEmployeeAsync(EmployeeModel employee);
    ValueTask<int> InsertEmployeesAsync(IEnumerable<EmployeeModel> employees);
    ValueTask<int> UpdateEmployeeAsync(EmployeeModel employee);
}