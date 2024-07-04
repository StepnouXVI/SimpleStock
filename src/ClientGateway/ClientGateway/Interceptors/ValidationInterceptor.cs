using FluentValidation;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace ClientGateway.Interceptors;

public class ValidationInterceptor(IServiceProvider serviceProvider): Interceptor
{
    public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        var validator = serviceProvider.GetRequiredService<IValidator<TRequest>>();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument,
                $"errors: {string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage))}"));
        }
        return base.UnaryServerHandler(request, context, continuation);
    }
}