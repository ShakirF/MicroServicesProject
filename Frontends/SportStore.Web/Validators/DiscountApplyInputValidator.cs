using FluentValidation;
using SportStore.Web.Models.Discounts;

namespace SportStore.Web.Validators;

public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
{
    public DiscountApplyInputValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("endirim bos olmamalidir");
    }
}

