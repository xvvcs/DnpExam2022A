using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryContracts;

namespace EfcRepositories;

public class DataAccess : IDataAccess
{
    private readonly StudentContext _context;
    
    public DataAccess(StudentContext context)
    {
        _context = context;
    }
    
    public async Task<Student> CreateStudentAsync(Student student)
    {
        EntityEntry<Student> entityEntry = await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        Console.WriteLine($"Student with ID created.");
        return entityEntry.Entity;
    }

    public async Task<ICollection<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.Include(s => s.Grades).ToListAsync();
    }

    public async Task AddGradeToStudentAsync(int studentID, GradeInCourse grade)
    {
        var student = await _context.Students.FindAsync(studentID);
        if (student == null)
        {
            throw new InvalidOperationException($"Student with ID {studentID} not found.");
        }
        if (student.Grades == null)
        {
            student.Grades = new List<GradeInCourse>();
        }
        student.Grades.Add(grade);
        await _context.SaveChangesAsync();
    }

    public async Task<Student> GetStudentByIdAsync(int studentID)
    {
        return await _context.Students.FindAsync(studentID);
    }
    
    public async Task<StatisticsOverwievDTO> GetCourseStatistics(string courseCode)
    {
        var students = await GetAllStudentsAsync();
        var grades = students.SelectMany(s => s.Grades).Where(g => g.CourseCode == courseCode).ToList();
        var studentsPassed = grades.Count(g => g.Grade >= 2);
        var courseStudentsNumber = grades.Count();
        var average = grades.Average(g => g.Grade);
        var averageOfPassed = grades.Where(g => g.Grade >= 2).Average(g => g.Grade);
        var orderedGrades = grades.OrderBy(g => g.Grade).ToList();
        var median = orderedGrades.Count % 2 == 0 ? (orderedGrades[orderedGrades.Count / 2].Grade + orderedGrades[orderedGrades.Count / 2 - 1].Grade) / 2 : orderedGrades[orderedGrades.Count / 2].Grade;
        
        StatisticsOverwievDTO dto = new StatisticsOverwievDTO(courseCode, studentsPassed, courseStudentsNumber, average, averageOfPassed, median);
        
        Console.WriteLine("Statistics retrieved." + dto.ToString());
        return dto;
    }
}