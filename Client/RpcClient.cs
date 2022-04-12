using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Common.Interceptors.Interceptors;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace Client;

public class RpcClient
{
    private readonly string _url;
    private GrpcChannel? _channel;

    private GrpcChannel Channel
    {
        get
        {
            if (_channel != null && _channel.State != ConnectivityState.Shutdown)
                return _channel;

            return _channel ??= GrpcChannel.ForAddress(_url, new GrpcChannelOptions
            {
                HttpHandler = new SocketsHttpHandler
                {
                    EnableMultipleHttp2Connections = true,
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(30)
                }
            });
        }
    }

    public Interceptor? Interceptor { get; set; }

    public bool AllowUnencrypted
    {
        get => GrpcClientFactory.AllowUnencryptedHttp2;
        set => GrpcClientFactory.AllowUnencryptedHttp2 = value;
    }

    public RpcClient(string url)
    {
        _url = url;
    }

    public TOutput Create<TOutput>(Dictionary<string, string>? headers = null) where TOutput : class
    {
        var metadata = new Metadata();
        if (headers != null)
            foreach (var (k, v) in headers)
                metadata.Add(k, v);

        var invoker = Channel.Intercept(new GrpcClientContext(metadata));

        if (Interceptor is not null)
        {
            invoker = invoker.Intercept(Interceptor);
        }

        return invoker.CreateGrpcService<TOutput>();
    }
}