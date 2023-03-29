using FluentValidation;
using SportStore.Web.Models.Catalogs;

namespace SportStore.Web.Validators;

public class ProductCreateInputValidator : AbstractValidator<ProductCreateInput>
{
    public ProductCreateInputValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("ad bos olmamalidir");
        RuleFor(x => x.Description).NotEmpty().WithMessage("aciqlama hissesi bos olmamalidir");
        RuleFor(x => x.Feature.Size).InclusiveBetween(1, 100).WithMessage("olcu hissesi bos olmamalidir");
        RuleFor(x => x.Price).NotEmpty().WithMessage("qiymet hissesi bos olmamalidir").ScalePrecision(2, 6).WithMessage("xetali pul formati");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("kateqoriyani secin");
    }
}

