using System.Threading.Tasks;
using Application;
using Common.Dto;
using Common.Services;
using ProtoBuf.Grpc;

namespace gRPC.Services
{
    public class TestService : ITestService
    {

        private readonly ITestSession _test;

        public TestService(ITestSession test)
        {
            _test = test;
        }

        public async Task<TestResultDto> TestAsync(TestRequestDto requestDto, CallContext context)
        {
            return await _test.TestAsync(requestDto);
        }

        public async Task<TestResultDto> TestAsync(TestRequestDto requestDto)
        {
            return await _test.TestAsync(requestDto);
        }

        public TestResultDto Test(TestRequestDto requestDto, CallContext context)
        {
            return _test.Test(requestDto);
        }
    }
}