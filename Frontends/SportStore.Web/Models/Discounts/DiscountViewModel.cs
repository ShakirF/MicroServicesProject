﻿namespace SportStore.Web.Models.Discounts;

public class DiscountViewModel
{
	public string UserId { get; set; } = null!;
	public int Rate { get; set; }
	public string Code { get; set; } = null!;

}

