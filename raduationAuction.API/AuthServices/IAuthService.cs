using raduationAuction.API.Validation;

namespace raduationAuction.API.AuthServices
{
    public interface IAuthService
    {
        Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default);

    }
}
