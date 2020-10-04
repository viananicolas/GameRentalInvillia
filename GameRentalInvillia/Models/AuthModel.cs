using System;

namespace GameRentalInvillia.Web.Models
{
    public class AuthModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}