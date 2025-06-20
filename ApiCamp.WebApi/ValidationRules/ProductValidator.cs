using ApiCamp.WebApi.Entities;
using FluentValidation;

namespace ApiCamp.WebApi.ValidationRules {


    public class ProductValidator:AbstractValidator<Product>

    {
        public ProductValidator() {

            RuleFor(x => x.ProductName).NotEmpty().WithMessage("::: Please Provide a Product Name!");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("::: Minimum Two Characters Length Required!");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("::: Maximum Fifty Character Length!");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("::: Please Provide a Product Price!")
                .LessThan(0).WithMessage("::: Price Must Be Greater Than 0$!")
                .GreaterThan(1000).WithMessage("::: Price Can Not Be Greater Than 1000$");

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("::: Please Provide a Product Description");
        }
    }

}