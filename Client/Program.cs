using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Common.Dto;
using Common.Services;

namespace Client
{
    public class Program
    {
        /// <summary>
        /// You can change url in LaunchSetting.json on gRPC/Properties project
        /// </summary>
        private const string Url = "http://localhost:2020";

        public static async Task Main(string[] args)
        {
            // You can add header typeof Dictionary<string, string>
            // var (test, context) = RpcClient.Create<ITestService>(Url, new Dictionary<string, string>());
            
            // Create client gRPC with interface service and url 
            var test = RpcClient.Create<ITestService>(Url);

            var requestDto = new TestRequestDto
            {
                Id = 1
            };
            
            // var result = test.Test(new TestRequestDto { Id = 1}, context);
            
            // Send request and get result of async
            var result = await test.TestAsync(requestDto);

            var json = JsonSerializer.Serialize(result);
            Console.WriteLine(json);
        }
        
    }
}