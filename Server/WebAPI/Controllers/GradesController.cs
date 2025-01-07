using DTOs;
using EfcRepositories;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController
{
    private readonly IDataAccess _dataAccess;
    
    public GradesController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    
    [HttpGet("{courseCode}")]
    public async Task<ActionResult<StatisticsOverwievDTO>> GetCourseStatistics(string courseCode)
    {
        Console.WriteLine("Get statistics.....");
        return await _dataAccess.GetCourseStatistics(courseCode);
    }
}