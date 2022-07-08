using Beers.Domain.Brand;

namespace Beers.Application.AppServices.BrandService
{
    public interface IBrandAppService
    {
        public Task<List<Brand>> Get();
    }
}
