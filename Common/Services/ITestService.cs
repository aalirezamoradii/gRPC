using System.ServiceModel;
using System.Threading.Tasks;
using Common.Dto;

namespace Common.Services
{
    [ServiceContract(Name = "rpc/test")]
    public interface ITestService
    {
        [OperationContract(Name = "test_async", AsyncPattern = true)]
        Task<TestResultDto> TestAsync(TestRequestDto requestDto);

        [OperationContract(Name = "test_async_request", AsyncPattern = true)]
        Task<TestResultDto> TestAsync(InheritanceTestDto requestDto);
        
        [OperationContract(Name = "test_async_result", AsyncPattern = false)]
        InheritanceTestDto Test(InheritanceTestDto requestDto);
        
        [OperationContract(Name = "test", AsyncPattern = false)]
        TestResultDto Test(TestRequestDto requestDto);
    }
}