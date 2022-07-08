using Beers.Domain.Brand;

namespace Beers.Core.Interfaces.DataServices
{
    public interface IBrandDataService
    {
        public Task<List<Brand>> Get();
    }
}
