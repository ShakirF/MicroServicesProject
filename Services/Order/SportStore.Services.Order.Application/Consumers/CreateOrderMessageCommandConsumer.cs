using MassTransit;
using SportStore.Services.Order.Infrastructure;
using SportStore.Shared.Messages;

namespace SportStore.Services.Order.Application.Consumers;

public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
{
	private readonly OrderDbContext _orderDbContext;

	public CreateOrderMessageCommandConsumer(OrderDbContext orderDbContext)
	{
		this._orderDbContext = orderDbContext;
	}

	public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
	{
		var newAddress = new Domain.OrderAggregate.Address(context.Message.Province, context.Message.District, context.Message.Street,
			context.Message.ZipCode, context.Message.Line);

		Domain.OrderAggregate.Order order = new Domain.OrderAggregate.Order(context.Message.BuyerId, newAddress);

		context.Message.OrderItems.ForEach(x =>
		{
			order.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl, x.Quantity);
		});

		await _orderDbContext.Orders.AddAsync(order);

		await _orderDbContext.SaveChangesAsync();
	}
}

