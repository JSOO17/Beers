namespace Beers.Domain.Beer
{
    public class Beer
    {
        public int IdBeer { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
    }
}
