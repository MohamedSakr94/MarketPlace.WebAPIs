using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MarketPlace.BL
{
    public static class Helpers
    {
        //private readonly UserManager<User> userManager;
        //private readonly IConfiguration configuration;

        //public Helpers(IConfiguration configuration, UserManager<User> userManager)
        //{
        //    this.configuration = configuration;
        //    this.userManager = userManager;
        //}

        public static string HashPassword(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            HashAlgorithm algorithm = SHA256.Create();
            return BitConverter.ToString(algorithm.ComputeHash(inputBytes))
            .Replace("-", "").ToLowerInvariant();
        }
        public static SymmetricSecurityKey SecretKeyBuilder(IConfiguration configuration)
        {
            string key = configuration.GetSection("SecretKey").ToString()!;

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        public static string GenerateJWT_Token(IConfiguration configuration, UserReadDetailsDTO user)
        {
            List<Claim> claimList = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var algorithm = SecurityAlgorithms.HmacSha256Signature;
            var signingCredentials = new SigningCredentials(SecretKeyBuilder(configuration), algorithm);
            var token = new JwtSecurityToken(
                claims: claimList,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(10));

            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}
