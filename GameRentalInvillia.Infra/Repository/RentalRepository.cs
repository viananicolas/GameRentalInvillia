using GameRentalInvillia.Core.Entities;
using GameRentalInvillia.Core.Interface;
using GameRentalInvillia.Infra.Data;

namespace GameRentalInvillia.Infra.Repository
{
    public class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        public RentalRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}