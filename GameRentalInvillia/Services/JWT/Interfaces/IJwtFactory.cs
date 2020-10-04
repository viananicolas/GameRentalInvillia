using System;
using System.Threading.Tasks;
using GameRentalInvillia.Web.Services.JWT.Models;

namespace GameRentalInvillia.Web.Services.JWT.Interfaces
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(Guid id, string email, string name, string[] roles);

        Guid? ValidateToken(string token);
    }
}
