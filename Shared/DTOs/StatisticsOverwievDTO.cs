namespace DTOs;

public class StatisticsOverwievDTO
{
    public string CourseCode { get; set; }
    public int? TotalNumOfPassedStudents { get; set; }
    public int? TotalNumOfStudents { get; set; }
    public double? AverageGradeOverall { get; set; }
    public double? AvgGradeOfPassed { get; set; }
    public double? MedianGrade { get; set; }
    
    public StatisticsOverwievDTO(string courseCode, int? totalNumOfPassedStudents, int? totalNumOfStudents, double? averageGradeOverall, double? avgGradeOfPassed, double? medianGrade)
    {
        CourseCode = courseCode;
        TotalNumOfPassedStudents = totalNumOfPassedStudents;
        TotalNumOfStudents = totalNumOfStudents;
        AverageGradeOverall = averageGradeOverall;
        AvgGradeOfPassed = avgGradeOfPassed;
        MedianGrade = medianGrade;
    }
    
    public override string ToString()
    {
        return $"Course code: {CourseCode}\nTotal number of students: {TotalNumOfStudents}\nTotal number of passed students: {TotalNumOfPassedStudents}\nAverage grade overall: {AverageGradeOverall}\nAverage grade of passed students: {AvgGradeOfPassed}\nMedian grade: {MedianGrade}";
    }
}