using SportStore.Web.Models.Orders;

namespace SportStore.Web.Services.Interfaces;

public interface IOrderService
{
    /// <summary>
    /// Sinxron elaqe - birbasa order mikroservisine istek edilicek
    /// </summary>
    /// <param name="checkoutInfoInput"></param>
    /// <returns></returns>
    Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput);

    /// <summary>
    /// Asinxron elaqe - sifaris melumatlari rabbitMQ-ya gonderilecek
    /// </summary>
    /// <param name="checkoutInfoInput"></param>
    /// <returns></returns>
    Task<OrderSuspendViewModel> SuspendOrder(CheckoutInfoInput checkoutInfoInput);

    Task<List<OrderViewModel>> GetOrder();
}

