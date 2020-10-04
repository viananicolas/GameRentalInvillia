using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Application.ViewModel.Friend;

namespace GameRentalInvillia.Application.Interface
{
    public interface IFriendService
    {
        IEnumerable<FriendViewModel> GetAll();
        Task<FriendViewModel> GetById(Guid id);
        void Add(FriendFormViewModel friendFormViewModel);
        void UpdateById(Guid id, FriendFormViewModel friendFormViewModel);
        void DeleteById(Guid id);
    }
}