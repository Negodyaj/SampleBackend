using Microsoft.AspNetCore.Authorization;
using SampleBackend.Models;

namespace SampleBackend.Configuration;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public CustomAuthorizeAttribute(UserRole[] roles)
    {
        Roles = string.Join(',', roles.Select(t => (int)t).ToArray());
    }
}
