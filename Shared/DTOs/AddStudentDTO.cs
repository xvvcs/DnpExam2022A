namespace DTOs;

public class AddStudentDTO
{
    public string Name { get; set; }
    public string Programme { get; set; }
    
    public AddStudentDTO(string name, string programme)
    {
        Name = name;
        Programme = programme;
    }
    
    public AddStudentDTO(){}
}