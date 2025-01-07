using DTOs;
using Entities;

namespace RepositoryContracts;

public interface IDataAccess
{
    Task<Student> CreateStudentAsync(Student student);
    Task<ICollection<Student>> GetAllStudentsAsync();
    Task AddGradeToStudentAsync(int studentID, GradeInCourse grade);
    Task<Student> GetStudentByIdAsync(int studentID);
    Task<StatisticsOverwievDTO> GetCourseStatistics(string courseCode);
}