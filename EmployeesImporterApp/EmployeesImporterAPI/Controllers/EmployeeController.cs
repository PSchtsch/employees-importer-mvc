using Microsoft.AspNetCore.Mvc;

namespace EmployeesImporterAPI.Controllers;

[ApiController]
[Route("employee")]
public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string GetAll()
    {
        return "sus all";
    }

    [HttpGet()]
    [Route("{id}")]
    public string GetOne(string id)
    {
        return $"sus {id}";
    }
}
