using System.Runtime.Serialization;

namespace Common.Dto
{
    [DataContract]
    public class TestRequestDto
    {
        [DataMember(Order = 1)]
        public long Id { get; set; }
    }
}