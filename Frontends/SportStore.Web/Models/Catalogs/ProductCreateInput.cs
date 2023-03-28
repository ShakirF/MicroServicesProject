using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Catalogs;

public class ProductCreateInput
{
    [Display(Name = "Məhsulun adı")]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "Məhsulun açıqlaması")]
    [Required]
    public string? Description { get; set; }

    [Display(Name = "Məhsulun qiyməti")]
    [Required]
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    public string? UserId { get; set; }
    public FeatureViewModel? Feature { get; set; }


    [Display(Name = "Məhsulun kateqoriyası")]
    [Required]
    public string CategoryId { get; set; } = null!;

    [Display(Name = "Məhsulun şəkli")]
    public IFormFile PhotoFormFile { get; set; }
}

