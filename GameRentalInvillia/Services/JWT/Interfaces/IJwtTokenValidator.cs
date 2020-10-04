using System.Security.Claims;

namespace GameRentalInvillia.Web.Services.JWT.Interfaces
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
