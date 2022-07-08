using Beers.Domain.Beer;

namespace Beers.Core.Interfaces.AppServices.BeerServices
{
    public interface IBeerAppService
    {
        public Task<List<Beer>> Get();
        public Task<Beer> Create(Beer beer);
    }
}
