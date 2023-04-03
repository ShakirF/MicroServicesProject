using MediatR;
using SportStore.Services.Order.Application.Dtos;
using SportStore.Shared.Dtos;

namespace SportStore.Services.Order.Application.Queries;

public class GetOrdersByUserIdQuery : IRequest<Response<List<OrderDto>>>
{
	public string? UserId { get; set; }
}

