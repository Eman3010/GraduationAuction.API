using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using raduationAuction.API.AuthServices;
using raduationAuction.API.Validation;

namespace raduationAuction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("")]
        public async Task<IActionResult> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.GetTokenAsync(request.Email, request.Password, cancellationToken);

            return authResult is null ? BadRequest("Invalid email/password") : Ok(authResult);
        }
    }

}
