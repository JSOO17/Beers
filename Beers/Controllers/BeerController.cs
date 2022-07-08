using Beers.Core.Interfaces.AppServices.BeerServices;
using Beers.Application.AppServices.BrandService;
using Beers.Domain.Beer;
using Beers.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Beers.Controllers
{
    public class BeerController : Controller
    {
        private readonly IBeerAppService _beerAppService;
        private readonly IBrandAppService _brandAppService;

        private const string DataValueFieldBrand = "IdBrand";
        private const string DataTextFieldBrand = "Name";
        private const string ViewDataBrands = "Brands";

        public BeerController(IBeerAppService beerAppService, IBrandAppService brandAppService)
        {
            _beerAppService = beerAppService;
            _brandAppService = brandAppService;
        }

        public async Task<IActionResult> Index()
        {
            var beers = await _beerAppService.Get();

            return View(beers);
        }

        public async Task<IActionResult> CreateAsync()
        {
            await LoadSelectBrands();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = new Beer
                {
                    Name = model.Name,
                    BrandId = model.BrandId
                };

                await _beerAppService.Create(beer);

                return RedirectToAction(nameof(Index));
            }

            await LoadSelectBrands();

            return View(model);
        }

        private async Task LoadSelectBrands()
        {
            var brands = await _brandAppService.Get();

            ViewData[ViewDataBrands] = new SelectList(brands, DataValueFieldBrand, DataTextFieldBrand);
        }
    }
}
