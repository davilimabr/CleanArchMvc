using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ClubsController : Controller
    {
        private readonly IClubService _clubService;

        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet]
        [Route("Clubs")]
        public async Task<IActionResult> Index()
        {
            var clubs = await _clubService.GetClubsAsync();
            return View(clubs);
        }
    }
}
