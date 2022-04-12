using ProtoBuf;

namespace Common.Dto
{
    [ProtoContract]
    public class TestRequestDto
    {
        [ProtoMember(1)] public long Id { get; set; }
    }
}