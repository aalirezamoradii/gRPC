using System.Collections.Generic;
using Grpc.Core;
using Grpc.Net.Client;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;

namespace Client
{
    public static class RpcClient
    {
        public static (TOutput, CallContext) Create<TOutput>(string url, Dictionary<string, string> headers,
            bool allowUnencrypted = true) where TOutput : class
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = allowUnencrypted;
            var channel = GrpcChannel.ForAddress(url);
            var file = channel.CreateGrpcService<TOutput>();
            if (headers == null) return (file, new CallContext());
            var metadata = new Metadata();
            foreach (var (k, v) in headers)
                metadata.Add(k, v);

            return (file, new CallContext(new CallOptions(metadata)));
        }

        public static TOutput Create<TOutput>(string url, bool allowUnencrypted = true) where TOutput : class
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = allowUnencrypted;
            var channel = GrpcChannel.ForAddress(url);
            var file = channel.CreateGrpcService<TOutput>();

            return file;
        }
    }
}