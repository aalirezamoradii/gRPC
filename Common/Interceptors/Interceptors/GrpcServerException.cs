using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Common.Interceptors.Interceptors;

public class GrpcServerException : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
        ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (Exception exception)
        {
            if (exception is RpcException)
                throw;

            throw new RpcException(new Status(StatusCode.Internal, exception.Message, exception));
        }
    }
}