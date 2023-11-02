using EmployeesImporterAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesImporterAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository repository)
    {
        _employeeRepository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetAll()
    {
        var employees = await _employeeRepository.GetAllEmployeesAsync();

        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeModel>> GetOneById(int id)
    {
        var employee = await _employeeRepository.GetEmployeeAsync(id);
        if (employee == null)
        {
            return NotFound($"Employee by given id: {id} was not found");
        }

        return Ok(employee);
    }

    [HttpGet("{searchTerm}")]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetBySearchTerm(string searchTerm)
    {
        var employees = await _employeeRepository.GetEmployeesAsync(searchTerm);
        if (!employees.Any())
        {
            return NotFound($"Employees like: {searchTerm} were not found");
        }

        return Ok(employees);
    }

    //Insert Set?
    //Insert one?

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateEmployeeRequest request)
    {
        var result = VerifyUpdateRequest(request);
        if (result is not OkResult)
        {
            return result;
        }

        //var sus = await _employeeRepository.UpdateEmployeeAsync(employee);

        throw new NotImplementedException();
    }

    private ActionResult VerifyUpdateRequest(UpdateEmployeeRequest request)
    {
        if (request is null)
        {
            return BadRequest("Request body is empty");
        }

        if (string.IsNullOrEmpty(request.Forename)
            && string.IsNullOrEmpty(request.Surename))
            //and so on
        {
            return BadRequest("Empty fields");
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _employeeRepository.DeleteEmployeeAsync(id);

        return Ok();
    }
}
