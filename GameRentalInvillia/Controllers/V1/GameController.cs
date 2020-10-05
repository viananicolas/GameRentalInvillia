using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/v1/[controller]"), ApiController, Authorize]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet, Produces("application/json", Type = typeof(IEnumerable<GameViewModel>))]
        public IActionResult GetAll()
        {
            return Ok(_gameService.GetAll());
        }
        [HttpGet("{id}"), Produces("application/json", Type = typeof(GameViewModel))]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _gameService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(GameFormViewModel model)
        {
            _gameService.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, GameFormViewModel model)
        {
            _gameService.UpdateById(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _gameService.DeleteById(id);
            return Ok();
        }
    }
}
