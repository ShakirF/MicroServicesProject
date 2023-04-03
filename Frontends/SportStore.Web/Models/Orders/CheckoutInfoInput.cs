using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models.Orders;

public class CheckoutInfoInput
{

	[Display(Name = "City")]
	public string Province { get; set; } = null!;

	[Display(Name = "District")]
	public string District { get; set; } = null!;

	[Display(Name = "Street")]
	public string Street { get; set; } = null!;

	[Display(Name = "Zip Code")]
	public string ZipCode { get; set; } = null!;

	[Display(Name = "Line")]
	public string Line { get; set; } = null!;

	[Display(Name = "Card Name")]
	public string CardName { get; set; } = null!;

	[Display(Name = "Card Number")]
	public string CardNumber { get; set; } = null!;

	[Display(Name = "Last modefied date")]
	public string Expiration { get; set; } = null!;

	[Display(Name = "CVV/CVC2")]
	public string CVV { get; set; } = null!;

}

