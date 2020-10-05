using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Rental;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/v1/[controller]"), ApiController, Authorize]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly ILogger _logger;
        public RentalController(IRentalService rentalService,
            ILogger<RentalController> logger)
        {
            _rentalService = rentalService;
            _logger = logger;
        }
        [HttpGet, Produces("application/json", Type = typeof(IEnumerable<RentalViewModel>))]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Started method GetAll");
            return Ok(_rentalService.GetAll());
        }
        [HttpGet("{id}"), Produces("application/json", Type = typeof(RentalViewModel))]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Started method GetById");
            return Ok(await _rentalService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(RentalFormViewModel model)
        {
            _logger.LogInformation("Started method Add");
            _rentalService.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, RentalFormViewModel model)
        {
            _logger.LogInformation("Started method Update");
            _rentalService.UpdateById(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation("Started method Delete");
            _rentalService.DeleteById(id);
            return Ok();
        }
    }
}
