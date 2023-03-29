using SportStore.Web.Models.Orders;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Services;

public class OrderService : IOrderService
{
    public Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderViewModel>> GetOrder()
    {
        throw new NotImplementedException();
    }

    public Task SuspendOrder(CheckoutInfoInput checkoutInfoInput)
    {
        throw new NotImplementedException();
    }
}

