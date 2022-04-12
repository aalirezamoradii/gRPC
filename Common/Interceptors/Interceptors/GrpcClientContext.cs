using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Common.Interceptors.Interceptors;

public class GrpcClientContext : Interceptor
{
    private readonly Metadata? _metadata;

    public GrpcClientContext(Metadata? metadata)
    {
        _metadata = metadata;
    }

    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        context = new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host,
            new CallOptions(_metadata));
        return base.AsyncUnaryCall(request, context, continuation);
    }
}