using Application;
using Common.Interceptors.Interceptors;
using gRPC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddCodeFirstGrpc(options =>
{
    options.EnableDetailedErrors = true;
    options.Interceptors.Add<GrpcServerException>();
});
services.AddScoped<ITestSession, TestSession>();

var app = builder.Build();

app.MapGrpcService<TestService>();

app.Run();