using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Application.ViewModel.Game;

namespace GameRentalInvillia.Application.Interface
{
    public interface IGameService
    {
        IEnumerable<GameViewModel> GetAll();
        Task<GameViewModel> GetById(Guid id);
        void Add(GameFormViewModel gameFormViewModel);
        void UpdateById(Guid id, GameFormViewModel gameFormViewModel);
        void DeleteById(Guid id);
    }
}