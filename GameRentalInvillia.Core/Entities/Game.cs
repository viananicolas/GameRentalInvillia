using System;
using GameRentalInvillia.Core.Common.Enum;
using GameRentalInvillia.Core.Entities.Base;

namespace GameRentalInvillia.Core.Entities
{
    public class Game : BaseEntity
    {
        public Game()
        {
            CreatedAt = DateTime.Now;
        }
        public string GameName { get; set; }
        public int ReleaseYear { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public Platform Platform { get; set; }
    }
}