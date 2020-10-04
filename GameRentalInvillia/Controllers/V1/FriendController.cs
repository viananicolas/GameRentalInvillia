using System;
using System.Threading.Tasks;
using GameRentalInvillia.Application.Interface;
using GameRentalInvillia.Application.ViewModel.Friend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameRentalInvillia.Web.Controllers.V1
{
    [Route("api/v1/[controller]"), ApiController, Authorize]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_friendService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _friendService.GetById(id));
        }

        [HttpPost]
        public IActionResult Add(FriendFormViewModel model)
        {
            _friendService.Add(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, FriendFormViewModel model)
        {
            _friendService.UpdateById(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _friendService.DeleteById(id);
            return Ok();
        }
    }
}
