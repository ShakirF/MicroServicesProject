using FluentValidation;
using SportStore.Web.Models.Catalogs;

namespace SportStore.Web.Validators;

public class ProductCreateInputValidator : AbstractValidator<ProductCreateInput>
{
	public ProductCreateInputValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("name must not be empty");
		RuleFor(x => x.Description).NotEmpty().WithMessage("description must not be empty");
		RuleFor(x => x.Feature.Size).InclusiveBetween(1, 100).WithMessage("size must not be empty");
		RuleFor(x => x.Price).NotEmpty().WithMessage("price must not be empty").ScalePrecision(2, 6).WithMessage("incorrect currency format");
		RuleFor(x => x.CategoryId).NotEmpty().WithMessage("choose category");
	}
}

