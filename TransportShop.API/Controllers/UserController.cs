using Microsoft.AspNetCore.Mvc;
using TransportShop.BLL.DTO.Request;
using TransportShop.BLL.DTO.Response;
using TransportShop.BLL.Interfaces;
using TransportShop.BLL.Services;
using TransportShop.DAL.Entities;

namespace TransportShop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService userService;
        private ITokenService tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request, CancellationToken cancellationToken)
        {
            await userService.SignInAsync(request, cancellationToken);
            return Ok();
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequest request, CancellationToken cancellationToken)
        {
            await userService.SignUpAsync(request, cancellationToken);
            return Ok();
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request, CancellationToken cancellationToken)
        {
            TokenResponse response = await userService.RefreshTokenAsync(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetMyProfile(CancellationToken cancellationToken)
        {
            UserProfileResponse response = await userService.GetMyProfileByJwtAsync(HttpContext.User);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await userService.GetAllUsersAsync(cancellationToken);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = await userService.GetUserByIdAsync(id, cancellationToken);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            await userService.DeleteUserAsync(id, cancellationToken);
            return Ok();
        }


    }
}
