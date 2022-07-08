using Beers.Core.Interfaces.AppServices.BeerServices;
using Beers.Domain.Beer;
using Microsoft.AspNetCore.Mvc;

namespace Beers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly IBeerAppService _appService;

        public ApiBeerController(IBeerAppService appService)
        {
            _appService = appService;
        }

        public async Task<List<Beer>> Index()
        {
            return await _appService.Get();
        }
    }
}
