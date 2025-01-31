using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class TrophiesController : Controller
    {
        private readonly ITrophyService _trophyService;

        public TrophiesController(ITrophyService trophyService)
        {
            _trophyService = trophyService;
        }

        [HttpGet]
        [Route("Trophies")]
        public async Task<IActionResult> Index()
        {
            var trophies = await _trophyService.GetTrophiesAsync();
            return View(trophies);
        }
    }
}
