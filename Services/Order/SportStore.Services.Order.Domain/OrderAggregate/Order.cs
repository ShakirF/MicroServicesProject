﻿using SportStore.Services.Order.Domain.Core;

namespace SportStore.Services.Order.Domain.OrderAggregate;

public class Order : Entity, IAggregateRoot
{
	public DateTime CreatedDate { get; set; }
	public Address Address { get; set; } = null!;
	public string BuyerId { get; set; } = null!;
	private readonly List<OrderItem> _orderItems;
	public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

	public Order()
	{

	}
	public Order(string buyerId, Address address)
	{
		_orderItems = new List<OrderItem>();
		CreatedDate = DateTime.Now;
		BuyerId = buyerId;
		Address = address;
	}

	public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl, int quantity)
	{
		var existProduct = _orderItems.Any(x => x.ProductId == productId);
		if (!existProduct)
		{
			var newOrderItem = new OrderItem(productId, productName, pictureUrl, price, quantity);
			_orderItems.Add(newOrderItem);
		}
	}

	public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
}

