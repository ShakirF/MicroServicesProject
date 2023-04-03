namespace SportStore.Services.Basket.Dtos;

public class BasketDto
{
	public string? UserId { get; set; }
	public string? DiscountCode { get; set; }
	public int? DiscountRate { get; set; }
	public List<BasketItemDto> BasketItems { get; set; } = null!;

	public decimal TotalPrice
	{
		get => BasketItems.Sum(b => b.Price * b.Quantity);
	}
}

