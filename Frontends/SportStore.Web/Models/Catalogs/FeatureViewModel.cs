using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Catalogs;

public class FeatureViewModel
{

    [Display(Name = "Məhsulun ölçüsü")]
    public int Size { get; set; }
}

