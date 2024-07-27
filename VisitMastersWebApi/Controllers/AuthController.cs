using Application.Contracts.Identity;
using Application.Models.Identity;
using Domain.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace VisitMastersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Authentication>> Login([FromBody] AuthRequest request)
        {
            var authentication = await _authService.Login(request);
            return Ok(authentication);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            var register = await _authService.Register(request);
            return Ok(register);
        }
    }
}
