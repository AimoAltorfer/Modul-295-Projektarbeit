using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly SkiServiceManagementContext _context;

    public EmployeeController(SkiServiceManagementContext context)
    {
        _context = context;
    }

    
}
