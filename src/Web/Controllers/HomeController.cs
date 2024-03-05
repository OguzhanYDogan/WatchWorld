using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeViewModelServise _homeViewModelServise;

        public HomeController(ILogger<HomeController> logger, IHomeViewModelServise homeViewModelServise)
        {
            _logger = logger;
            _homeViewModelServise = homeViewModelServise;
        }

        public async Task<IActionResult> Index(int? categoryId, int? brandId, int pageId = 1)
        {
            var vm = await _homeViewModelServise.GetHomeViewModelAsync(categoryId, brandId, pageId);
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
