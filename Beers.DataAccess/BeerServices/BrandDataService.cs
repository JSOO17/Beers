using Beers.Core.Interfaces.DataServices;
using Beers.Domain.Brand;
using Beers.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Beers.DataAccess.BeerServices
{
    public class BrandDataService : IBrandDataService
    {
        private readonly IntroAspContext _context;
        private readonly ILogger<BrandDataService> _logger;

        public BrandDataService(IntroAspContext context, ILogger<BrandDataService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Brand>> Get()
        {
            _logger.LogInformation("Fetching brands");

            var query = from brand in _context.Brands
                        select new Brand
                        {
                            IdBrand = brand.IdBrand,
                            Name = brand.Name,
                        };

            var brands = await query.ToListAsync();

            _logger.LogInformation("Fetched {0} brands", brands.Count);

            return brands;
        }
    }
}
