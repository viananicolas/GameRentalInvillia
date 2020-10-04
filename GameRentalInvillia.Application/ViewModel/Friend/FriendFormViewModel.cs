using System.ComponentModel.DataAnnotations;

namespace GameRentalInvillia.Application.ViewModel.Friend
{
    public class FriendFormViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}