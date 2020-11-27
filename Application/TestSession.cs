using System.Threading.Tasks;
using Common.Dto;

namespace Application
{
    public class TestSession : ITestSession
    {
        public Task<TestResultDto> TestAsync(TestRequestDto requestDto)
        {
            return Task.FromResult(ReadData(requestDto));
        }

        public TestResultDto Test(TestRequestDto requestDto)
        {
            return ReadData(requestDto);
        }

        private static TestResultDto ReadData(TestRequestDto requestDto)
        {
            // From database or anything 
            return requestDto.Id switch
            {
                1 => new TestResultDto
                {
                    Name = "Alireza",
                    Family = "Moradi",
                    Age = 1,
                    Height = 188.7,
                    Money = 234890000
                },
                2 => new TestResultDto
                {
                    Name = "You",
                    Family = "Your family",
                    Age = 99,
                    Height = 180.7,
                    Money = 2034890000
                },
                _ => new TestResultDto()
            };
        }
    }
}