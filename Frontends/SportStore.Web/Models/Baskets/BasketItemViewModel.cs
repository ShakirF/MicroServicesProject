﻿namespace SportStore.Web.Models.Baskets;

public class BasketItemViewModel
{
    public int Quantity { get; set; }
    public string ProductId { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }

    private decimal? DiscountAppliedPrice { get; set; }

    public decimal GetCurrentPrice
    {
        get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price;
    }
    public void AppliedDiscount(decimal disCountPrice)
    {
        DiscountAppliedPrice = disCountPrice;
    }
}
