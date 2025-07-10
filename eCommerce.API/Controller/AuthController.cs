using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
namespace eCommerce.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
            _usersService = usersService; 
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDTO registerRequestDTO)
        {
            if (registerRequestDTO == null)
            {
                return BadRequest("Invalid registration data.");
            }
            AuthenticationResponseDTO? authenticationResponseDTO = await _usersService.Register(registerRequestDTO);

            if (authenticationResponseDTO == null || authenticationResponseDTO.Success == false)
            {
                return BadRequest(authenticationResponseDTO);
            }
            return Ok(authenticationResponseDTO);
        }
        [HttpPost("login")]
        public async Task<IActionResult>Login(LoginRequestDTO loginRequestDTO) {
            if (loginRequestDTO is null)
            {
                return BadRequest("Invalid login data.");
            }
            AuthenticationResponseDTO? authenticationResponseDTO = await _usersService.Login(loginRequestDTO);
            if (authenticationResponseDTO == null || authenticationResponseDTO.Success == false)
            {
                return Unauthorized(authenticationResponseDTO);
            }
            return Ok(authenticationResponseDTO);
        }
    }
}
