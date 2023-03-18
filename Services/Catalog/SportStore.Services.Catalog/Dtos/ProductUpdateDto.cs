namespace SportStore.Services.Catalog.Dtos;

public class ProductUpdateDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Picture { get; set; }
    public string? UserId { get; set; }
    public FeatureDto? Feature { get; set; }
    public string CategoryId { get; set; } = null!;
}

