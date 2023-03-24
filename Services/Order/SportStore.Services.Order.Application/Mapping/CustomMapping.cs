using AutoMapper;
using SportStore.Services.Order.Application.Dtos;
using SportStore.Services.Order.Domain.OrderAggregate;

namespace SportStore.Services.Order.Application.Mapping;

public class CustomMapping : Profile
{
    public CustomMapping()
    {
        CreateMap<Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();

    }
}

