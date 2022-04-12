using System.Threading.Tasks;
using Common.Dto;

namespace Application
{
    public interface ITestSession
    {
        Task<TestResultDto> TestAsync(TestRequestDto requestDto);
        TestResultDto Test(TestRequestDto requestDto);
        Task<TestResultDto> TestAsync(InheritanceTestDto requestDto);
    }
}