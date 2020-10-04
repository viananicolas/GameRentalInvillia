using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Friend;
using GameRentalInvillia.Core.Entities;
using GameRentalInvillia.Core.Interface;

namespace GameRentalInvillia.Application.Service
{
    public class FriendService : IFriendService
    {
        private readonly IRepository<Friend> _friendRepository;
        public FriendService(IRepository<Friend> friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public IEnumerable<FriendViewModel> GetAll()
        {
            return _friendRepository.GetAll().Select(DomainToViewModel);
        }

        public async Task<FriendViewModel> GetById(Guid id)
        {
            return DomainToViewModel(await _friendRepository.GetAsync(id));
        }

        public async void Add(FriendFormViewModel friendFormViewModel)
        {
            await _friendRepository.AddAsync(ViewModelToDomain(friendFormViewModel));
        }

        public async void UpdateById(Guid id, FriendFormViewModel friendFormViewModel)
        {
            var friend = await _friendRepository.GetAsync(id);
            if (friend == null)
                throw new Exception("No friend found.");
            friend.Address = friendFormViewModel.Address;
            friend.Email = friendFormViewModel.Email;
            friend.FullName = friendFormViewModel.FullName;
            friend.TelephoneNumber = friendFormViewModel.TelephoneNumber;
            await _friendRepository.UpdateAsync(friend);
        }

        public async void DeleteById(Guid id)
        {
            var friend = await _friendRepository.GetAsync(id);
            if (friend == null)
                throw new Exception("No friend found.");
            friend.Delete();
            await _friendRepository.UpdateAsync(friend);
        }

        private static FriendViewModel DomainToViewModel(Friend friend)
        {
            return new FriendViewModel
            {
                Id = friend.Id,
                Address = friend.Address,
                Email = friend.Email,
                FullName = friend.FullName,
                TelephoneNumber = friend.TelephoneNumber
            };
        }

        private static Friend ViewModelToDomain(FriendFormViewModel friendFormViewModel)
        {
            return new Friend
            {
                Address = friendFormViewModel.Address,
                Email = friendFormViewModel.Email,
                FullName = friendFormViewModel.FullName,
                TelephoneNumber = friendFormViewModel.TelephoneNumber
            };
        }
    }
}