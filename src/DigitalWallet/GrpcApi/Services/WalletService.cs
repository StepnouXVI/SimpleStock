using Grpc.Core;

namespace GrpcApi.Services;

public class WalletService : GrpcApi.WalletService.WalletServiceBase
{
    public override Task<BalanceTransferResponse> BalanceTransfer(BalanceTransferRequest request, ServerCallContext context)
    {
        return base.BalanceTransfer(request, context);
    }

    public override Task<ReserveTransferResponse> ReserveTransfer(ReserveTransferRequest request, ServerCallContext context)
    {
        return base.ReserveTransfer(request, context);
    }

    public override Task<ExecuteReservedTransferResponse> ExecuteReservedTransfer(ExecuteReservedTransferRequest request, ServerCallContext context)
    {
        return base.ExecuteReservedTransfer(request, context);
    }

    public override Task<ReleaseReservedMoneyResponse> ReleaseReservedMoney(ReleaseReservedMoneyRequest request, ServerCallContext context)
    {
        return base.ReleaseReservedMoney(request, context);
    }
}