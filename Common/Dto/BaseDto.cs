using ProtoBuf;

namespace Common.Dto;

[ProtoInclude(2, typeof(InheritanceTestDto))]
[ProtoContract]
public class BaseDto
{
    [ProtoMember(1)] public long Id { get; set; }
}