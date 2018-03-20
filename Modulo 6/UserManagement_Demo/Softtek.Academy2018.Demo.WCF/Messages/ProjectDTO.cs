using System.Runtime.Serialization;

namespace Softtek.Academy2018.Demo.WCF.Messages
{
    [DataContract]
    public class ProjectDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public string TechnologyStack { get; set; }
    }
}