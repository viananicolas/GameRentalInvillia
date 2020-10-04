using System;

namespace GameRentalInvillia.Application.ViewModel.Game
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public int ReleaseYear { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Platform { get; set; }
    }
}