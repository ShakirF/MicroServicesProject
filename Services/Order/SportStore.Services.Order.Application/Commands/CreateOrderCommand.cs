﻿
using MediatR;
using SportStore.Services.Order.Application.Dtos;
using SportStore.Shared.Dtos;

namespace SportStore.Services.Order.Application.Commands;

public class CreateOrderCommand : IRequest<Response<CreatedOrderDto>>
{
    public string BuyerId { get; set; }

    public List<OrderItemDto> OrderItems { get; set; }

    public AddressDto Address { get; set; }
}
