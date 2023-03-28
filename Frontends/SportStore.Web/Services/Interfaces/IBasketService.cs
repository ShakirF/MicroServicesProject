﻿using SportStore.Web.Models.Baskets;

namespace SportStore.Web.Services.Interfaces;

public interface IBasketService
{
    Task<bool> SaveOrUpdate(BasketViewModel basketViewModel);

    Task<BasketViewModel> Get();

    Task<bool> Delete();

    Task AddBasketItem(BasketItemViewModel basketItemViewModel);

    Task<bool> RemoveBasketItem(string productId);

    Task<bool> ApplyDiscount(string discountCode);

    Task<bool> CancelApplyDiscount();
}

