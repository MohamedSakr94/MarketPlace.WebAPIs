using MarketPlace.BL;
using MarketPlace.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public UserController(IConfiguration configuration, UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }

        #region login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO credentials)
        {
            #region Verification
            User? user = await userManager.FindByNameAsync(credentials.UserName);
            if (user is null)
            {
                return Unauthorized();
            }

            bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, credentials.Password);
            if (!isPasswordCorrect)
            {
                return Unauthorized();
            }
            #endregion

            #region GenerateToken

            var claimsList = await userManager.GetClaimsAsync(user);
            var secretKey = configuration.GetValue<string>("SecretKey")!;
            var keyInBytes = Encoding.ASCII.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(keyInBytes);

            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                claims: claimsList,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(10));

            var tokenHandler = new JwtSecurityTokenHandler();
            return new TokenDTO
            {
                Token = tokenHandler.WriteToken(token)
            };
            #endregion
        }
        #endregion

        #region Register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(RegisterDTO registerDto)
        {
            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };
            var creationResult = await userManager.CreateAsync(user, registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors);
            }
            var claimsList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };
            await userManager.AddClaimsAsync(user, claimsList);

            return NoContent();
        }

        #endregion
    }
}