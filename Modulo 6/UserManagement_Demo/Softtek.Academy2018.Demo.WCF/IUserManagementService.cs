using Softtek.Academy2018.Demo.WCF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Softtek.Academy2018.Demo.WCF
{
    [ServiceContract]
    public interface IUserManagementService
    {
        [OperationContract]
        CreateUserResponse CreateUser(CreateUserRequest request);
        [OperationContract]
        GetUserResponse GetUser(GetUserRequest request);

        [OperationContract]
        DeleteUserResponse DeleteUser(DeleteUserRequest request);

        [OperationContract]
        UpdateUserResponse UpdateUser(UpdateUserRequest request);
    }
}
