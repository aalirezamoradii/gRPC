using System.Runtime.Serialization;

namespace Common.Dto
{
    [DataContract]
    public class TestResultDto
    {
        [DataMember(Order = 1)] public string Name { get; set; }
        [DataMember(Order = 2)] public string Family { get; set; }
        [DataMember(Order = 3)] public int Age { get; set; }

        /// <summary>
        /// By Cm
        /// </summary>
        [DataMember(Order = 4)]
        public double Height { get; set; }

        [DataMember(Order = 5)] public decimal Money { get; set; }
    }
}