using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Friend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/v1/[controller]"), ApiController, Authorize]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly ILogger _logger;
        public FriendController(IFriendService friendService, 
            ILogger<FriendController> logger)
        {
            _friendService = friendService;
            _logger = logger;
        }
        [HttpGet, Produces("application/json", Type = typeof(IEnumerable<FriendViewModel>))]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Started method GetAll");
            return Ok(_friendService.GetAll());
        }
        [HttpGet("{id}"), Produces("application/json", Type = typeof(FriendViewModel))]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Started method GetById");
            return Ok(await _friendService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(FriendFormViewModel model)
        {
            _logger.LogInformation("Started method Add");
            _friendService.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, FriendFormViewModel model)
        {
            _logger.LogInformation("Started method Update");
            _friendService.UpdateById(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation("Started method Delete");
            _friendService.DeleteById(id);
            return Ok();
        }
    }
}
