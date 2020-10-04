﻿using System.ComponentModel.DataAnnotations;

namespace GameRentalInvillia.Application.ViewModel.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}