using System.ComponentModel.DataAnnotations;
using GameRentalInvillia.Core.Common.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
        [Required, JsonConverter(typeof(StringEnumConverter))]
        public Platform Platform { get; set; }
    }
}