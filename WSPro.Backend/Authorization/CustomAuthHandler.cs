using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;

namespace WSPro.Backend.Authorization
{
    public class CustomAuthHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly IUserService _userService;

        public CustomAuthHandler(
            IOptionsMonitor<BasicAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService
        ) : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(token))
                return AuthenticateResult.NoResult();

            try
            {
                MePayload response = await _userService.GetMe<MePayload>();

                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, response.FirstName), new(ClaimTypes.Email, response.Email),
                    new(ClaimTypes.Role, response.Role.ToString())
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new GenericPrincipal(identity, new[] { response.Role.ToString() });
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            catch (Exception e)
            {
                return AuthenticateResult.Fail(e);
            }
        }
    }
}