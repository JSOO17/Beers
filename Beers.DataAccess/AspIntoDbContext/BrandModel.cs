using System;
using System.Collections.Generic;

namespace Beers.DataAccess.AspIntoDbContext
{
    public partial class BrandModel
    {
        public BrandModel()
        {
            Beers = new HashSet<BeerModel>();
        }

        public int IdBrand { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<BeerModel> Beers { get; set; }
    }
}
