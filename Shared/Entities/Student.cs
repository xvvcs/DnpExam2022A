namespace Entities;

public class Student
{
    public int studentId { get; set; }
    public string Name { get; set; }
    public string Programme { get; set; }
    public List<GradeInCourse> Grades { get; set; }
    
    public Student(){} // for efc
    
    
    public Student(string name, string programme)
    {
        Name = name;
        Programme = programme;
        Grades = new List<GradeInCourse>();
    }
    
    public Student(string name, string programme, int studentId)
    {
        Name = name;
        Programme = programme;
        this.studentId = studentId;
        Grades = new List<GradeInCourse>();
    }
    
    public override string ToString()
    {
        return $"Name: {Name}\nProgramme: {Programme}\nGrades: {string.Join(", ", Grades)}";
    }
}