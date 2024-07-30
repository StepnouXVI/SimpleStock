using FluentValidation;

namespace GrpcApi.Validators;

public class ReleaseReservedMoneyRequestValidator : AbstractValidator<ReleaseReservedMoneyRequest>
{
    public ReleaseReservedMoneyRequestValidator()
    {
        RuleFor(x => x.ReservationId)
            .NotNull()
            .NotEmpty();
    }
}