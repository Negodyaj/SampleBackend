﻿namespace SampleBackend.Models.Requests;

public class RegisterUserRequest
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone {  get; set; }
}
