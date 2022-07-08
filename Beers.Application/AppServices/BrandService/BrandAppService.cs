using Beers.Core.Interfaces.DataServices;
using Beers.Domain.Brand;

namespace Beers.Application.AppServices.BrandService
{
    public class BrandAppService : IBrandAppService
    {
        private readonly IBrandDataService _dataService;

        public BrandAppService(IBrandDataService dataService)
        {
            _dataService = dataService;
        }

        public Task<List<Brand>> Get()
        {
            return _dataService.Get();
        }
    }
}
