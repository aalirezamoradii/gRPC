using ProtoBuf;

namespace Common.Dto;

[ProtoContract]
public class InheritanceTestDto : BaseDto
{
    [ProtoMember(1)] public string Message { get; set; } = null!;
}