using System.Net.Http.Json;
using System.Text.Json;
using DTOs;
using Entities;

namespace Services;

public class StudentHttpClient: IStudentService
{
    private readonly HttpClient client;
    
    public StudentHttpClient(HttpClient httpClient)
    {
        client = httpClient;
    }
    
    public async Task AddStudentAsync(AddStudentDTO student)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync("api/students", student);
        if(!httpResponse.IsSuccessStatusCode)
        {
            string response = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine(response);
            throw new Exception(response);
        }
    }

    public async Task<ICollection<Student>> GetAllStudentsAsync()
    {
        HttpResponseMessage httpResponse = await client.GetAsync("api/students");
        if(!httpResponse.IsSuccessStatusCode)
        {
            string response = await httpResponse.Content.ReadAsStringAsync();
            throw new Exception(response);
        }
        return await httpResponse.Content.ReadFromJsonAsync<ICollection<Student>>();
    }

    public async Task AddGradeToStudentAsync(int studentID, GradeInCourse grade)
    {
        HttpResponseMessage httpResponse = await client.PostAsJsonAsync($"api/students/{studentID}/grades", grade);
        if(!httpResponse.IsSuccessStatusCode)
        {
            string response = await httpResponse.Content.ReadAsStringAsync();
            throw new Exception(response);
        }
        Console.WriteLine("Grade added");
    }
    
}
