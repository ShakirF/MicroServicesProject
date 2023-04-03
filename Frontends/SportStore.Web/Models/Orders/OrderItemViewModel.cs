namespace SportStore.Web.Models.Orders;

public class OrderItemViewModel
{
	public string ProductId { get; set; } = null!;
	public string ProductName { get; set; } = null!;
	public int Quantity { get; set; }
	public string PictureUrl { get; set; } = null!;
	public Decimal Price { get; set; }
}

