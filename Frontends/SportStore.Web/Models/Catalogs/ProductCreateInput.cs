using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Catalogs;

public class ProductCreateInput
{
	[Display(Name = "Product")]
	public string Name { get; set; } = null!;

	[Display(Name = "Description")]
	public string? Description { get; set; }

	[Display(Name = "Price")]
	public decimal Price { get; set; }
	public string? Picture { get; set; }
	public string? UserId { get; set; }
	public FeatureViewModel Feature { get; set; } = null!;


	[Display(Name = "Category")]
	public string CategoryId { get; set; } = null!;

	[Display(Name = "Picture")]
	public IFormFile PhotoFormFile { get; set; } = null!;
}

