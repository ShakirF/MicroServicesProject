namespace SportStore.Web.Models.Catalogs;

public class ProductViewModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string ShortDescription { get => Description.Length > 100 ? Description.Substring(0, 100) + "..." : Description; }
    public decimal Price { get; set; }

    public string? UserId { get; set; }

    public string? Picture { get; set; }


    public DateTime CreatedDate { get; set; }
    public FeatureViewModel? Feature { get; set; }


    public string CategoryId { get; set; } = null!;


    public CategoryViewModel Category { get; set; } = null!;
}

