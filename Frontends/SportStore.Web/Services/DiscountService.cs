using SportStore.Shared.Dtos;
using SportStore.Web.Models.Discounts;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Services;

public class DiscountService : IDiscountService
{
    private readonly HttpClient _httpClient;

    public DiscountService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<DiscountViewModel> GetDiscount(string discoundCode)
    {
        var response = await _httpClient.GetAsync($"discounts/getbycode/{discoundCode}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var discount = await response.Content.ReadFromJsonAsync<Response<DiscountViewModel>>();
        return discount.Data;


    }
}

