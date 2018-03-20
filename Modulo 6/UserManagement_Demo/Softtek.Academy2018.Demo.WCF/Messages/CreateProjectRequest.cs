using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Softtek.Academy2018.Demo.WCF.Messages
{
    [DataContract]
    public class CreateProjectRequest : BaseRequest
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public string TechnologyStack { get; set; }
    }
}