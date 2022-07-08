using Beers.Core.Interfaces.DataServices;
using Beers.Domain.Beer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Beers.DataAccess.AspIntoDbContext;
using Beers.DataAccess;

namespace IntoAsp.DataAccess.BeerServices
{
    public class BeerDataService : IBeerDataService
    {
        private readonly IntroAspContext _context;
        private readonly ILogger<BeerDataService> _logger;

        public BeerDataService(IntroAspContext context, ILogger<BeerDataService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Beer>> Get()
        {
            _logger.LogInformation("Fetching beers");

            var query = from beer in _context.Beers
                        join brand in _context.Brands on beer.BrandId equals brand.IdBrand
                        select new Beer
                        {
                            IdBeer = beer.IdBeer,
                            BrandId = brand.IdBrand,
                            Name = beer.Name,
                            BrandName = brand.Name,
                        };

            var beers = await query.ToListAsync();

            _logger.LogInformation("Fetched {0} beers", beers.Count);

            return beers;
        }

        public async Task<Beer> Create(Beer beer)
        {
            _logger.LogInformation("Creating a beer");

            var beerModel = new BeerModel
            {
                Name = beer.Name,
                BrandId = beer.BrandId,
            };

            _context.Add(beerModel);

            await _context.SaveChangesAsync();

            _logger.LogInformation("One beer was created. Id: {0}. Name: {0}", beerModel.IdBeer, beerModel.Name);

            beer.IdBeer = beerModel.IdBeer;

            return beer;
        }
    }
}
