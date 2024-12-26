using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SampleBackend.Configuration;
using SampleBackend.Models;
using SampleBackend.Models.Requests;
using SampleBackend.Models.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleBackend.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public ActionResult<Guid> Register([FromBody] RegisterUserRequest request)
    {
        var addedUserId = Guid.NewGuid();
        return StatusCode(StatusCodes.Status503ServiceUnavailable, "Постучитесь через недельку");
        return Created($"/api/users/{addedUserId}", addedUserId);
    }

    // "api/users/login"
    [HttpPost("login")]
    public ActionResult<AuthenticatedResponse> LogIn([FromBody] LoginRequest request)
    {
        if (request.Email == "test@mail.com")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "42"),
                new Claim(
                    ClaimTypes.Role, 
                    request.Password == "123" ? 
                        ((int)UserRole.Manager).ToString() :
                        ((int)UserRole.SuperManager).ToString()
                ),
                new Claim(
                    ClaimTypes.Role, UserRole.RegularUser.ToString()
                )
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthConstants.TokenSecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: AuthConstants.TokenIssuer,
                audience: AuthConstants.TokenAudience,
                claims: claims,                
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthenticatedResponse { Token = tokenString });
        }

        return Unauthorized();
    }

    [HttpGet("{id}")]
    public UserWithOrdersResponse GetUserById([FromRoute] Guid id)
    {
        var user = new UserWithOrdersResponse();
        return user;
    }

    [HttpGet]
    public OkResult GetUsers()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
    {
        return Forbid("This action is not allowed");
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser([FromRoute] Guid id)
    {
        return NoContent();
    }

    [HttpPatch("{id}/deactivate")]
    public IActionResult DeactivateUser([FromRoute] Guid id)
    {
        var human = new Human();
        var parrot = new Parrot();
        ProcessSpeakAction(human);
        ProcessSpeakAction(parrot);
        return NoContent();
    }

    void ProcessSpeakAction<T>(T speaker) where T : ISpeakable
    {
        speaker.Speak();
    }
}


interface ISpeakable
{
    void Speak();
}

class Human : ISpeakable
{
    public void Speak()
    {
        Console.WriteLine("I'm a human");
    }
}

class Parrot : ISpeakable
{
    public void Speak()
    {
        Console.WriteLine("I'm a parrot, sychechki");
    }
}