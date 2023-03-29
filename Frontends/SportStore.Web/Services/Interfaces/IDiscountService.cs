using SportStore.Web.Models.Discounts;

namespace SportStore.Web.Services.Interfaces;

public interface IDiscountService
{
    Task<DiscountViewModel> GetDiscount(string discoundCode);
}

