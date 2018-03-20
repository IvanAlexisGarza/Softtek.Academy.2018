using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Softtek.Academy2018.Demo.WCF.Messages
{
    [DataContract]
    public class DeleteUserRequest : BaseRequest
    {
        [DataMember]
        public int UserId { get; set; }
    }
}