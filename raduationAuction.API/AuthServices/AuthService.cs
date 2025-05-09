using Microsoft.AspNetCore.Identity;
using raduationAuction.API.Model;
using raduationAuction.API.Validation;

namespace raduationAuction.API.AuthServices
{
    public class AuthService(UserManager<User> userManager, IJwtProvider jwtProvider) : IAuthService
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        public async Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
                return null;

            var isValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!isValidPassword)
                return null;

            var (token, expiresIn) = _jwtProvider.GenerateToken(user);

            return new AuthResponse(user.Id, user.Email, user.Name, token, expiresIn);
        }
    }
}
    
