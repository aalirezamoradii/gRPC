using ProtoBuf;

namespace Common.Dto
{
    [ProtoContract]
    public class TestResultDto
    {
        [ProtoMember(1)] public string Name { get; set; } = null!;
        [ProtoMember(2)] public string Family { get; set; } = null!;
        [ProtoMember(3)] public int Age { get; set; }

        /// <summary>
        /// By Cm
        /// </summary>
        [ProtoMember(4)]
        public double Height { get; set; }

        [ProtoMember(5)] public decimal Money { get; set; }
    }
}