using System.ComponentModel.DataAnnotations;

namespace Beers.Models.ViewModels
{
    public class BeerViewModel
    {
        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
