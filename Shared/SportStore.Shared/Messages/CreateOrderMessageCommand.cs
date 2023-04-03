using System;
using System.Collections.Generic;

namespace SportStore.Shared.Messages
{
	public class CreateOrderMessageCommand
	{
		public CreateOrderMessageCommand()
		{
			OrderItems = new List<OrderItem>();
		}

		public string BuyerId { get; set; } = null!;
		public List<OrderItem> OrderItems { get; set; } = null!;
		public string Province { get; set; } = null!;
		public string District { get; set; } = null!;
		public string Street { get; set; } = null!;
		public string ZipCode { get; set; } = null!;
		public string Line { get; set; } = null!;

	}

	public class OrderItem
	{
		public string ProductId { get; set; } = null!;
		public string ProductName { get; set; } = null!;
		public string PictureUrl { get; set; } = null!;
		public Decimal Price { get; set; }
	}
}
