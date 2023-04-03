namespace SportStore.Services.Basket.Dtos;

public class BasketItemDto
{
	public int Quantity { get; set; }
	public string? StockPictureUrl { get; set; }
	public string? Picture { get; set; }
	public string ProductId { get; set; } = null!;
	public string ProductName { get; set; } = null!;
	public decimal Price { get; set; }
}

