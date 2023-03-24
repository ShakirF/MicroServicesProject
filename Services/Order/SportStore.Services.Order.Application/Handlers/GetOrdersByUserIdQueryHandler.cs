
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportStore.Services.Order.Application.Dtos;
using SportStore.Services.Order.Application.Mapping;
using SportStore.Services.Order.Application.Queries;
using SportStore.Services.Order.Infrastructure;
using SportStore.Shared.Dtos;

namespace SportStore.Services.Order.Application.Handlers;

public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Response<List<OrderDto>>>
{
    private readonly OrderDbContext _orderDbContext;

    public GetOrdersByUserIdQueryHandler(OrderDbContext orderDbContext)
    {
        this._orderDbContext = orderDbContext;
    }

    public async Task<Response<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();

        if (!orders.Any())
        {
            return Response<List<OrderDto>>.Success(new List<OrderDto>(), 200);
        }

        var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);

        return Response<List<OrderDto>>.Success(ordersDto, 200);
    }
}

