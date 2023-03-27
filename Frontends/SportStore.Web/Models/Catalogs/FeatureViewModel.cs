using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Catalogs;

public class FeatureViewModel
{

    [Display(Name = "Məhsulun ölçüsü")]
    [Required]
    public int Size { get; set; }
}

