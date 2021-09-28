using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsumesIssue.Authentication
{
    public class TestAuthenticationHandler : AuthenticationHandler<TestAuthenticationSchemeOptions>
    {
        public TestAuthenticationHandler(
            IOptionsMonitor<TestAuthenticationSchemeOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, loggerFactory, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
            => Task.FromResult(
                Options?.AuthenticatedUser != null
                    ? AuthenticateResult.Success(new AuthenticationTicket(Options.AuthenticatedUser, "Test"))
                    : AuthenticateResult.Fail("No authenticated user specified."));
    }
}