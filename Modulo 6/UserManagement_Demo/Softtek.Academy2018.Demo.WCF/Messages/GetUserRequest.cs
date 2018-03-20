using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Softtek.Academy2018.Demo.WCF.Messages
{   [DataContract]
    public class GetUserRequest:BaseRequest
    {   [DataMember]
        public int UserId { get; set; }

        
    }
}