using FluentValidation;

namespace GrpcApi.Validators;

public class BalanceTransferRequestValidator : AbstractValidator<BalanceTransferRequest>
{
    public BalanceTransferRequestValidator()
    {
        RuleFor(x => x.Amount)
            .NotNull()
            .NotEmpty()
            .Custom(
                (x, contex) =>
                {
                    if (!(decimal.TryParse(x, out var value)) || value < 0)
                        contex.AddFailure($"{x} (Amount) is not a valid number or less than 0");
                });
        
        RuleFor(x => x.Currency)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.TransactionId)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.From)
            .NotNull()
            .NotEmpty();
        
        RuleFor(x => x.To)
            .NotNull()
            .NotEmpty();
    }
}