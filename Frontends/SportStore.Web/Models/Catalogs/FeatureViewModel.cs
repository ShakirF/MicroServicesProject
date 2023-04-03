using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Catalogs;

public class FeatureViewModel
{

	[Display(Name = "Size Of Product")]
	public int Size { get; set; }
}

