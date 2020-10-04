using System;

namespace GameRentalInvillia.Core.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Deleted { get; private set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedAt { get; set; }
        public void Delete()
        {
            Deleted = true;
        }
    }
}