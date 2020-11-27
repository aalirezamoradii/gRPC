using System.ServiceModel;
using System.Threading.Tasks;
using Common.Dto;
using ProtoBuf.Grpc;

namespace Common.Services
{
    [ServiceContract(Name = "Test/Rpc")]
    public interface ITestService
    {

        /// <summary>
        /// CallContext for send and receive header such az authorization or client ip
        /// </summary>
        /// <param name="requestDto"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [OperationContract(Name = "TestAsyncContext", AsyncPattern = true)]
        Task<TestResultDto> TestAsync(TestRequestDto requestDto, CallContext context);
        
        /// <summary>
        /// If don't need CallContext
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        [OperationContract(Name = "TestAsync", AsyncPattern = true)]
        Task<TestResultDto> TestAsync(TestRequestDto requestDto);
        
        /// <summary>
        /// If don't need async
        /// </summary>
        /// <param name="requestDto"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [OperationContract(Name = "Test", AsyncPattern = false)]
        TestResultDto Test(TestRequestDto requestDto, CallContext context);
    }
}