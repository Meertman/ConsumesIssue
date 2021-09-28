using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ConsumesIssue.Authentication
{
    public class TestAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public ClaimsPrincipal AuthenticatedUser { get; set; }
    }
}