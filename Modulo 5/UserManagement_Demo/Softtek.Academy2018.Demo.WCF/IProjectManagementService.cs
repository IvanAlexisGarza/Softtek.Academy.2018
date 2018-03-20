using Softtek.Academy2018.Demo.WCF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Softtek.Academy2018.Demo.WCF
{    
    [ServiceContract]
    public interface IProjectManagementService
    {
        [OperationContract]
        CreateProjectResponse CreateProject(CreateProjectRequest request);

        [OperationContract]
        GetAllProjectsResponse GetAllProjects(GetAllProjectsRequest request);
    }
}
