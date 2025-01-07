using System.Net.Http.Json;
using DTOs;

namespace Services;

public class GradesHttpClient : IGradeService
{
    private readonly HttpClient client;
    
    public GradesHttpClient(HttpClient httpClient)
    {
        client = httpClient;
    }
    
    public async Task<StatisticsOverwievDTO> GetCourseStatisticsAsync(string courseCode)
    {
        Console.WriteLine("Getting statistics");
        HttpResponseMessage httpResponse = await client.GetAsync($"api/grades/{courseCode}");
        if(!httpResponse.IsSuccessStatusCode)
        {
            string response = await httpResponse.Content.ReadAsStringAsync();
            throw new Exception(response);
        }
        return await httpResponse.Content.ReadFromJsonAsync<StatisticsOverwievDTO>();
    }
}