using System;

namespace GameRentalInvillia.Application.ViewModel.Rental
{
    public class RentalFormViewModel
    {
        public Guid GameId { get; set; }
        public Guid FriendId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}