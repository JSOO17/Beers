using Beers.Core.Interfaces.AppServices.BeerServices;
using Beers.Core.Interfaces.DataServices;
using Beers.Domain.Beer;

namespace Beers.Application.AppServices
{
    public class BeerAppService : IBeerAppService
    {
        private readonly IBeerDataService _dataService;

        public BeerAppService(IBeerDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<List<Beer>> Get()
        {
            return await _dataService.Get();
        }

        public async Task<Beer> Create(Beer beer)
        {
            return await _dataService.Create(beer);
        }
    }
}
