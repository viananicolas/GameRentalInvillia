using System.ComponentModel.DataAnnotations;
using GameRentalInvillia.Core.Common.Enum;

namespace GameRentalInvillia.Application.ViewModel.Game
{
    public class GameFormViewModel
    {
        [Required]
        public string GameName { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public Platform Platform { get; set; }
    }
}