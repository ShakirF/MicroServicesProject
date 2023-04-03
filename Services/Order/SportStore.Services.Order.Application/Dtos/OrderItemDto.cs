namespace SportStore.Services.Order.Application.Dtos;

public class OrderItemDto
{
	public string ProductId { get; set; } = null!;
	public string ProductName { get; set; } = null!;
	public string PictureUrl { get; set; } = null!;
	public Decimal Price { get; set; }
}

