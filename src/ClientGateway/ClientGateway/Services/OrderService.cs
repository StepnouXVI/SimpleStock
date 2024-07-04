using Grpc.Core;
using ClientGateway;
using Google.Protobuf.WellKnownTypes;

namespace ClientGateway.Services;

public class OrderService : ClientGateway.OrderService.OrderServiceBase
{
    public override Task<PlaceOrderResponse> PlaceOrder(PlaceOrderRequest request, ServerCallContext context)
    {
        var result = new PlaceOrderResponse();
        result.Id = 1;
        result.Status = OrderStatus.New;
        result.CreationTime = new Timestamp();
        result.FilledQuantity = 0;
        result.RemainingQuantity = request.Quantity;
        return Task.FromResult(result);
    }
}