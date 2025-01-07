
namespace Entities;

public class GradeInCourse
{
    public int GradeInCourseId { get; set; }
    public string CourseCode { get; set; }
    public int Grade { get; set; }
    
    private GradeInCourse(){} // for efc
    
    public GradeInCourse(string courseCode, int grade)
    {
        CourseCode = courseCode;
        Grade = grade;
    }
    
    
    public override string ToString()
    {
        return $"{CourseCode}: {Grade}";
    }
}