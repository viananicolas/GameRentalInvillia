using System;
using GameRentalInvillia.Core.Entities.Base;

namespace GameRentalInvillia.Core.Entities
{
    public class Friend : BaseEntity
    {
        public Friend()
        {
            CreatedAt = DateTime.Now;
        }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
    }
}