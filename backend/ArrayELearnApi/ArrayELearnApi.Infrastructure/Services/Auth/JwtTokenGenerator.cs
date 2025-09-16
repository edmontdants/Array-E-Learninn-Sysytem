using ArrayELearnApi.Application.Interfaces.Auth;
using ArrayELearnApi.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArrayELearnApi.Infrastructure.Services.Auth
{
    internal sealed class JwtTokenGenerator(IConfiguration configuration, UserManager<ApplicationUser> userManager) : IJwtTokenGenerator
    {
        public async Task<string> GenerateJwtTokenAsync(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.FullName ?? "FullName")
            };
            //.Concat(roleClaims);
            //.Union(roleClaims);
            //.ToList();

            // Add role claims to the claims list

            //foreach (var role in roles)
            //    claims.Add(new Claim(ClaimTypes.Role, role));

            //claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            //if (roleClaims.Any())
            //    claims.AddRange(roleClaims);

            claims.AddRange(roleClaims);
            claims.AddRange(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var expires = DateTime.Now.AddDays(Convert.ToDouble(configuration["Jwt:DurationInDays"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: configuration["Jwt:Issuer"],
                                             audience: configuration["Jwt:Audience"],
                                             claims: claims,
                                             expires: expires,
                                             signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
