using SportStore.Services.Basket.Dtos;
using SportStore.Shared.Dtos;

namespace SportStore.Services.Basket.Services;

public interface IBasketService
{
    Task<Response<BasketDto>> GetBasket(string userId);

    Task<Response<bool>> SaveOrUpdate(BasketDto dto);

    Task<Response<bool>> DeleteBasket(string userId);
}

