using Microsoft.AspNetCore.Mvc;
using Tutorial5.DTOs;
using Tutorial5.Services;

namespace Tutorial5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PrescriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
}