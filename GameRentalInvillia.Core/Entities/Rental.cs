using System;
using GameRentalInvillia.Core.Entities.Base;

namespace GameRentalInvillia.Core.Entities
{
    public class Rental : BaseEntity
    {
        public Rental()
        {
            CreatedAt = DateTime.Now;
        }
        public Friend Friend { get; set; }
        public Game Game { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}