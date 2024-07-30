using FluentValidation;

namespace GrpcApi.Validators;

public class ExecuteReservedTransferRequestValidator : AbstractValidator<ExecuteReservedTransferRequest>
{
    public ExecuteReservedTransferRequestValidator()
    {
        RuleFor(x => x.ReservationId)
            .NotNull()
            .NotEmpty();
    }
}