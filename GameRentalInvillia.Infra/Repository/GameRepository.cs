using GameRentalInvillia.Core.Entities;
using GameRentalInvillia.Core.Interface;
using GameRentalInvillia.Infra.Data;

namespace GameRentalInvillia.Infra.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}