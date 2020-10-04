using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Game;
using GameRentalInvillia.Core.Common.Extensions;
using GameRentalInvillia.Core.Entities;
using GameRentalInvillia.Core.Interface;

namespace GameRentalInvillia.Application.Service
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _gameRepository;
        public GameService(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IEnumerable<GameViewModel> GetAll()
        {
            return _gameRepository.GetAll().Select(DomainToViewModel);
        }

        public async Task<GameViewModel> GetById(Guid id)
        {
            return DomainToViewModel(await _gameRepository.GetAsync(id));
        }

        public void Add(GameFormViewModel gameFormViewModel)
        {
            _gameRepository.Add(ViewModelToDomain(gameFormViewModel));
        }

        public async void UpdateById(Guid id, GameFormViewModel gameFormViewModel)
        {
            var game = await _gameRepository.GetAsync(id);
            if (game == null)
                throw new Exception("No game found.");
            game.Developer = gameFormViewModel.Developer;
            game.GameName = gameFormViewModel.GameName;
            game.Platform = gameFormViewModel.Platform;
            game.Publisher = gameFormViewModel.Publisher;
            game.ReleaseYear = game.ReleaseYear;
            _gameRepository.Update(game);
        }

        public async void DeleteById(Guid id)
        {
            var game = await _gameRepository.GetAsync(id);
            if (game == null)
                throw new Exception("No game found.");
            game.Delete(); 
            _gameRepository.Update(game);
        }
        private static GameViewModel DomainToViewModel(Game game)
        {
            return new GameViewModel
            {
                Id = game.Id,
                Developer = game.Developer,
                GameName = game.GameName,
                Platform = game.Platform.GetDescription(),
                Publisher = game.Publisher,
                ReleaseYear = game.ReleaseYear
            };
        }

        private static Game ViewModelToDomain(GameFormViewModel gameFormViewModel)
        {
            return new Game
            {
                Developer = gameFormViewModel.Developer,
                GameName = gameFormViewModel.GameName,
                Platform = gameFormViewModel.Platform,
                Publisher = gameFormViewModel.Publisher,
                ReleaseYear = gameFormViewModel.ReleaseYear
            };
        }
    }
}