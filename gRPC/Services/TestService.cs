using System.Threading.Tasks;
using Application;
using Common.Dto;
using Common.Services;

namespace gRPC.Services;

public class TestService : ITestService
{
    private readonly ITestSession _test;

    public TestService(ITestSession test)
    {
        _test = test;
    }

    public async Task<TestResultDto> TestAsync(TestRequestDto requestDto)
    {
        return await _test.TestAsync(requestDto);
    }
    
    public async Task<TestResultDto> TestAsync(InheritanceTestDto requestDto)
    {
        return await _test.TestAsync(requestDto);
    }

    public InheritanceTestDto Test(InheritanceTestDto requestDto)
    {
        requestDto.Message = "OK";
        return requestDto;
    }

    public TestResultDto Test(TestRequestDto requestDto)
    {
        return _test.Test(requestDto);
    }
}