using System;
using System.ComponentModel.DataAnnotations;

namespace GameRentalInvillia.Application.ViewModel.Rental
{
    public class RentalFormViewModel
    {
        [Required]
        public Guid GameId { get; set; }
        [Required]
        public Guid FriendId { get; set; }
        [Required]
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}