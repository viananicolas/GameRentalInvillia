using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/v1/[controller]"), ApiController, Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ILogger _logger;
        public GameController(IGameService gameService,
            ILogger<GameController> logger)
        {
            _gameService = gameService;
            _logger = logger;
        }
        [HttpGet, Produces("application/json", Type = typeof(IEnumerable<GameViewModel>))]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Started method GetAll");
            return Ok(_gameService.GetAll());
        }
        [HttpGet("{id}"), Produces("application/json", Type = typeof(GameViewModel))]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Started method GetById");
            return Ok(await _gameService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(GameFormViewModel model)
        {
            _logger.LogInformation("Started method Add");
            _gameService.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, GameFormViewModel model)
        {
            _logger.LogInformation("Started method Update");
            _gameService.UpdateById(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _logger.LogInformation("Started method Delete");
            _gameService.DeleteById(id);
            return Ok();
        }
    }
}
