using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [Route("Players")]
        public async Task<IActionResult> Index()
        {
            var players = await _playerService.GetPlayersAsync();
            return View(players);
        }
    }
}
