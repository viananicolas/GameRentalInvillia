using System;

namespace GameRentalInvillia.Application.ViewModel.Friend
{
    public class FriendViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
    }
}