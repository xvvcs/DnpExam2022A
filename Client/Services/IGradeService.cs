using DTOs;

namespace Services;

public interface IGradeService
{
    Task<StatisticsOverwievDTO> GetCourseStatisticsAsync(string courseCode);
}