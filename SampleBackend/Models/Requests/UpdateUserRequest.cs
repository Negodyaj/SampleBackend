namespace SampleBackend.Models.Requests;

public class UpdateUserRequest
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
}
