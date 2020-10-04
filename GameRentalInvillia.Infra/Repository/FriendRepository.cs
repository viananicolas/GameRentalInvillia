using GameRentalInvillia.Core.Entities;
using GameRentalInvillia.Core.Interface;
using GameRentalInvillia.Infra.Data;

namespace GameRentalInvillia.Infra.Repository
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public FriendRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}