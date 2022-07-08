namespace Beers.DataAccess.AspIntoDbContext
{
    public partial class BeerModel
    {
        public int IdBeer { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BrandId { get; set; }

        public virtual BrandModel Brand { get; set; } = null!;
    }
}
