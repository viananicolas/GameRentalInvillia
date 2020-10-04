using System.Threading.Tasks;
using GameRentalInvillia.Web.Services.JWT.Models;

namespace GameRentalInvillia.Web.Services.JWT.Interfaces
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string email);
        string ValidateToken(string token);
    }
}
