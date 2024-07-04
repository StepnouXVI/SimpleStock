using FluentValidation;

namespace ClientGateway.Validation;

public class PlaceOrderRequestValidator : AbstractValidator<PlaceOrderRequest>
{
    public PlaceOrderRequestValidator()
    {
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Symbol).NotNull().NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
    }
}