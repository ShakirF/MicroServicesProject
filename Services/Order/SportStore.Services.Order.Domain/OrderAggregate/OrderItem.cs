using SportStore.Services.Order.Domain.Core;

namespace SportStore.Services.Order.Domain.OrderAggregate;

public class OrderItem : Entity
{
	public string ProductId { get; private set; } = null!;
	public string ProductName { get; private set; } = null!;
	public int Quantity { get; set; }
	public string PictureUrl { get; private set; } = null!;
	public Decimal Price { get; private set; }

	public OrderItem()
	{

	}
	public OrderItem(string productId, string productName, string pictureUrl, decimal price, int quantity)
	{
		ProductId = productId;
		ProductName = productName;
		Quantity = quantity;
		PictureUrl = pictureUrl;
		Price = price;
	}

	public void UpdateOrderItem(string productName, string pictureUrl, decimal price, int quantity)
	{
		ProductName = productName;
		Quantity = quantity;
		PictureUrl = pictureUrl;
		Price = price;
	}
}

