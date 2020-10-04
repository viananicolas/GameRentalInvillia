using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Application.ViewModel.Rental;

namespace GameRentalInvillia.Application.Interface
{
    public interface IRentalService
    {
        IEnumerable<RentalViewModel> GetAll();
        Task<RentalViewModel> GetById(Guid id);
        void Add(RentalFormViewModel rentalFormViewModel);
        void UpdateById(Guid id, RentalFormViewModel rentalFormViewModel);
        void DeleteById(Guid id);
    }
}