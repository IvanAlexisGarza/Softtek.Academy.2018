using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Softtek.Academy2018.Demo.WCF.Messages
{
    [DataContract]
    public class CreateProjectResponse : BaseResponse
    {
        [DataMember]
        public int ProjectId { get; set; }
    }
}