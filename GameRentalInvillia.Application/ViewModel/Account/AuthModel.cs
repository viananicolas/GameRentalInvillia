using System.ComponentModel.DataAnnotations;

namespace GameRentalInvillia.Application.ViewModel.Account
{
    public class AuthModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}