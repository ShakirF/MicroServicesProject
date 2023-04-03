namespace SportStore.Web.Models.Baskets;

public class BasketItemViewModel
{
	public int Quantity { get; set; }
	public string StockPictureUrl { get; set; } = null!;
	public string Picture { get; set; } = null!;
	public string ProductId { get; set; } = null!;
	public string ProductName { get; set; } = null!;
	public decimal Price { get; set; }

	public decimal TotalEachProduct { get => GetCurrentPrice * Quantity; }

	private decimal? DiscountAppliedPrice;
	public decimal GetCurrentPrice
	{
		get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price;
	}
	public void AppliedDiscount(decimal disCountPrice)
	{
		DiscountAppliedPrice = disCountPrice;
	}
}

