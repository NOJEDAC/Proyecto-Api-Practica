using Banking.Application.Auth.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Banking.Application.Auth.Jwt
{
    public class JwtProvider
    {
        public string BuildJwtToken(LoginViewModel loginViewModel)
        {
            var plainTextSecurityKey = Environment.GetEnvironmentVariable("JWT_KEY");
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(plainTextSecurityKey));
            var credentials = new SigningCredentials(
                signingKey,
                SecurityAlgorithms.HmacSha256);

            var notBefore = DateTime.UtcNow.AddSeconds(-1);
            double expirationMinutes = double.Parse(Environment.GetEnvironmentVariable("JWT_EXP_MINUTES") ?? "180");
            var expires = DateTime.UtcNow.AddMinutes(expirationMinutes);
            var payload = new JwtPayload(Environment.GetEnvironmentVariable("JWT_ISSUER"), Environment.GetEnvironmentVariable("JWT_AUDIENCE"), new List<Claim>(), notBefore, expires)
            {
                { "userId", loginViewModel.UserId.ToString() },
                { "userName", loginViewModel.Name },
                { "emailAddress", loginViewModel.EmailAddress },
                { "customers", loginViewModel.Customers },
                { "roles", loginViewModel.Roles },
                { "permissions", loginViewModel.Permissions }
            };
            foreach (var permission in loginViewModel.Permissions)
            {
                payload.Add(permission.Name, "true");
            }

            var jwtToken = new JwtSecurityToken(new JwtHeader(credentials), payload);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return jwtTokenHandler.WriteToken(jwtToken);
        }
    }
}
