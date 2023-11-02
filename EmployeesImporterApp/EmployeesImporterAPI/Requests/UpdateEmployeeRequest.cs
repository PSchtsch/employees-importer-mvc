namespace EmployeesImporterAPI.Requests;

//maybe nullable approach better
public class UpdateEmployeeRequest
{
    public string PayrollNumber { get; set; } = null!;
    public string Forename { get; set; } = null!;
    public string Surename { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public string Telephone { get; set; } = null!;
    public string Mobile { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Address2 { get; set; } = null!;
    public string Postcode { get; set; } = null!;
    public string EMailHome { get; set; } = null!;
    public DateOnly StartDate { get; set; }
}
