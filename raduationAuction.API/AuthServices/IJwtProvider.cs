using raduationAuction.API.Model;

namespace raduationAuction.API.AuthServices
{
    public interface IJwtProvider
    {
        (string token, int expiresIn) GenerateToken(User user);
    }
}
