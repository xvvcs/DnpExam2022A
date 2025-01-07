using DTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]

public class StudentsController
{
    private readonly IDataAccess _dataAccess;
    
    public StudentsController(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateStudent([FromBody] AddStudentDTO addStudent)
    {
        Console.WriteLine("ES");
        Student student = new Student(
            addStudent.Name,
            addStudent.Programme
        );
        
        await _dataAccess.CreateStudentAsync(student);
        return new OkResult();
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAllStudents()
    {
        return new OkObjectResult(await _dataAccess.GetAllStudentsAsync());
    }
    
    [HttpPost("{studentID}/grades")]
    public async Task<ActionResult> AddGradeToStudent(int studentID, [FromBody] GradeInCourse grade)
    {
        await _dataAccess.AddGradeToStudentAsync(studentID, grade);
        return new OkResult();
    }
}