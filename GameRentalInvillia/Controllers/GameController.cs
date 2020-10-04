using System;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalInvillia.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_gameService.GetAll());
        }
        [HttpGet("{id}")]
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
