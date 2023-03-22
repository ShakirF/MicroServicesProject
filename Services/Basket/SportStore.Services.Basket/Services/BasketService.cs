using SportStore.Services.Basket.Dtos;
using SportStore.Shared.Dtos;
using System.Text.Json;

namespace SportStore.Services.Basket.Services;

public class BasketService : IBasketService
{
    private readonly RedisService _redisService;

    public BasketService(RedisService redisService)
    {
        this._redisService = redisService;
    }

    public async Task<Response<bool>> DeleteBasket(string userId)
    {
        var status = await _redisService.GetDB().KeyDeleteAsync(userId);
        return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket not found", 404);
    }

    public async Task<Response<BasketDto>> GetBasket(string userId)
    {
        var existBasket = await _redisService.GetDB().StringGetAsync(userId);
        if (String.IsNullOrEmpty(existBasket))
        {
            return Response<BasketDto>.Fail("BAsket not found", 404);
        }
        return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
    }

    public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
    {
        var status = await _redisService.GetDB().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));

        return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket could not update or save", 500);
    }
}

