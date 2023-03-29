using SportStore.Web.Models.FakePayments;

namespace SportStore.Web.Services.Interfaces;

public interface IPaymentService
{
    Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
}

