using DTOs;
using Entities;

namespace Services;

public interface IStudentService
{
    Task AddStudentAsync(AddStudentDTO student);
    Task<ICollection<Student>> GetAllStudentsAsync();
    Task AddGradeToStudentAsync(int studentID, GradeInCourse grade);
}