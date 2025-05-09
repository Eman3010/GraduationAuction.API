namespace raduationAuction.API.Validation
{
    public record AuthResponse(
     string Id,
     string? Email,
     string Name,
     string Token,
     int ExpiresIn
 );
}
