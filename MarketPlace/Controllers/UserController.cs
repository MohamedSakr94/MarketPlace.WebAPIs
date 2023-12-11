using MarketPlace.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IConfiguration configuration;

        public UserController(IConfiguration configuration, IUserManager userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }

        #region login
        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginResponseDTO> Login(LoginDTO credentials)
        {
            UserReadDetailsDTO? user = userManager.GetByEmailAndPassword(credentials);
            if (user is null)
            {
                return Unauthorized();
            }

            LoginResponseDTO loginResponse = new()
            {
                UserReadDetails = user,
                Token = Helpers.GenerateJWT_Token(configuration, user)
            };
            return loginResponse;
        }
        #endregion

        #region Register
        [HttpPost]
        [Route("Register")]
        public ActionResult<UserReadDTO> Register(RegisterDTO registerDto)
        {
            UserReadDTO user = userManager.GetByEmail(registerDto.Email);
            if (user == null)
            {
                return userManager.Add(registerDto);
            }
            else return StatusCode(409);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = "JWT")]
        public ActionResult<UserReadDetailsDTO> GetById([FromHeader(Name = "Authorization")][Required] string Authorization, string id)
        {
            if (id == null) return BadRequest();
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id) return StatusCode(403);

            UserReadDetailsDTO? user = userManager.GetByIdWithDetails(id);

            if (user == null) return NotFound();

            return user;

        }

        #endregion
    }
}