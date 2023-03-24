using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportStore.Services.Order.Application.Commands;
using SportStore.Services.Order.Application.Queries;
using SportStore.Shared.ControllerBases;
using SportStore.Shared.Services;

namespace SportStore.Services.Order.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : CustomBaseController
{
    private readonly IMediator _mediator;
    private readonly ISharedIdentityService _sharedIdentityService;

    public OrdersController(IMediator mediator, ISharedIdentityService sharedIdentityService)
    {
        this._mediator = mediator;
        this._sharedIdentityService = sharedIdentityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var response = await _mediator.Send(new GetOrdersByUserIdQuery { UserId = _sharedIdentityService.GetUserId });
        return CreateActionResultInstance(response);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
    {
        var response = await _mediator.Send(createOrderCommand);
        return CreateActionResultInstance(response);
    }
}

