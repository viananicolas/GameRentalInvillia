using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Rental;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/v1/[controller]"), ApiController, Authorize]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet, Produces("application/json", Type = typeof(IEnumerable<RentalViewModel>))]
        public IActionResult GetAll()
        {
            return Ok(_rentalService.GetAll());
        }
        [HttpGet("{id}"), Produces("application/json", Type = typeof(RentalViewModel))]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _rentalService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(RentalFormViewModel model)
        {
            _rentalService.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, RentalFormViewModel model)
        {
            _rentalService.UpdateById(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _rentalService.DeleteById(id);
            return Ok();
        }
    }
}
