using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Rental;
using GameRentalInvillia.Core.Common.Extensions;
using GameRentalInvillia.Core.Entities;
using GameRentalInvillia.Core.Interface;

namespace GameRentalInvillia.Application.Service
{
    public class RentalService : IRentalService
    {
        private readonly IRepository<Rental> _rentalRepository;
        private readonly IRepository<Friend> _friendRepository;
        private readonly IRepository<Game> _gameRepository;

        public RentalService(IRepository<Rental> rentalRepository,
            IRepository<Friend> friendRepository,
            IRepository<Game> gameRepository)
        {
            _rentalRepository = rentalRepository;
            _friendRepository = friendRepository;
            _gameRepository = gameRepository;
        }
        public IEnumerable<RentalViewModel> GetAll()
        {
            return _rentalRepository.GetAll().Select(DomainToViewModel);
        }

        public async Task<RentalViewModel> GetById(Guid id)
        {
            return DomainToViewModel(await _rentalRepository.GetAsync(id));
        }

        public async void Add(RentalFormViewModel gameFormViewModel)
        {
            var game = await _gameRepository.GetAsync(gameFormViewModel.GameId);
            if (game == null)
                throw new Exception("No game found.");
            var friend = await _friendRepository.GetAsync(gameFormViewModel.FriendId);
            if (friend == null)
                throw new Exception("No friend found.");
            _rentalRepository.Add(ViewModelToDomain(gameFormViewModel, friend, game));
        }

        public async void UpdateById(Guid id, RentalFormViewModel gameFormViewModel)
        {
            var rental = await _rentalRepository.GetAsync(id);
            if (rental == null)
                throw new Exception("No rental found.");
            var game = await _gameRepository.GetAsync(gameFormViewModel.GameId);
            if (game == null)
                throw new Exception("No game found.");
            var friend = await _friendRepository.GetAsync(gameFormViewModel.FriendId);
            if (friend == null)
                throw new Exception("No friend found.");
            rental.RentalDate = gameFormViewModel.RentalDate;
            rental.ReturnDate = gameFormViewModel.ReturnDate;
            rental.Friend = friend;
            rental.Game = game;
            _rentalRepository.Update(rental);
        }

        public async void DeleteById(Guid id)
        {
            var rental = await _rentalRepository.GetAsync(id);
            if (rental == null)
                throw new Exception("No rental found.");
            rental.Delete();
            _rentalRepository.Update(rental);
        }
        private static RentalViewModel DomainToViewModel(Rental rental)
        {
            return new RentalViewModel
            {
                Id = rental.Id,
                RentalDate = rental.RentalDate,
                ReturnDate = rental.ReturnDate,
                FriendName = rental.Friend.FullName,
                GameName = rental.Game.GameName,
                Platform = rental.Game.Platform.GetDescription()
            };
        }

        private static Rental ViewModelToDomain(RentalFormViewModel rentalFormViewModel, Friend friend, Game game)
        {
            return new Rental
            {
                RentalDate = rentalFormViewModel.RentalDate,
                ReturnDate = rentalFormViewModel.ReturnDate,
                Friend = friend,
                Game = game
            };
        }
    }
}