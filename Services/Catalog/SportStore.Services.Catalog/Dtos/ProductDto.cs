namespace SportStore.Services.Catalog.Dtos;

public class ProductDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }


    public decimal Price { get; set; }

    public string? UserId { get; set; }

    public string? Picture { get; set; }


    public DateTime CreatedDate { get; set; }
    public FeatureDto? Feature { get; set; }


    public string CategoryId { get; set; } = null!;


    public CategoryDto Category { get; set; } = null!;
}

