using Beers.Application.AppServices.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace Beers.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandAppService _brandAppService;

        public BrandController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandAppService.Get();

            return View(brands);
        }
    }
}
