using System;

namespace GameRentalInvillia.Application.ViewModel.Rental
{
    public class RentalViewModel
    {
        public Guid Id { get; set; }
        public string FriendName { get; set; }
        public string GameName { get; set; }
        public string Platform { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}