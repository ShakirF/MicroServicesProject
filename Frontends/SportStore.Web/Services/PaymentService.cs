using SportStore.Web.Models.FakePayments;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Services;

public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;

    public PaymentService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput)
    {
        var response = await _httpClient.PostAsJsonAsync<PaymentInfoInput>("fakepayments", paymentInfoInput);

        return response.IsSuccessStatusCode;
    }
}

