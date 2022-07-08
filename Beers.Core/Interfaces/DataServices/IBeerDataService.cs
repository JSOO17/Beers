using Beers.Domain.Beer;

namespace Beers.Core.Interfaces.DataServices
{
    public interface IBeerDataService
    {
       public Task<List<Beer>> Get();
       public Task<Beer> Create(Beer beer);
    }
}
