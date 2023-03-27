namespace SportStore.Web.Models.Catalogs;

public class ProductUpdateInput
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    public string? UserId { get; set; }
    public FeatureViewModel? Feature { get; set; }
    public string CategoryId { get; set; } = null!;
}

