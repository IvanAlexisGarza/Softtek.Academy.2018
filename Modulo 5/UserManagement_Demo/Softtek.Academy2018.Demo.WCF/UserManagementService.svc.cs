using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WCF.Messages;

namespace Softtek.Academy2018.Demo.WCF
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserService _service;

        public UserManagementService()
        {
            IUserRepository repository = new UserDataRepository();
            _service = new UserService(repository);
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            if (request == null)
            {
                return new CreateUserResponse
                {
                    Success = false,
                    Message = "Error: request is null"
                };
            }

            User user = new User
            {
                IS = request.IS,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Salary = request.Salary,
            };

            int id = _service.Add(user);

            if (id == 0)
            {
                return new CreateUserResponse
                {
                    Success = false,
                    Message = "Error: unable to create user"
                };
            }

            return new CreateUserResponse
            {
                Success = true,
                UserId = id
            };
        }

        public DeleteUserResponse DeleteUser(DeleteUserRequest request)
        {
            bool deleted = false;

            if (request == null)
            {
                return new DeleteUserResponse
                {
                    Success = false,
                    Message = "Error, request is null"
                };
            }

            deleted = _service.Delete(request.UserId);

            if (!deleted)
            {
                return new DeleteUserResponse
                {
                    Success = false,
                    Message = "Error, unable to delete"
                };
            }

            return new DeleteUserResponse
            {
                Success = true,
                Message = "The user has been deleted successfully"
            };

        }

        public GetUserResponse GetUser(GetUserRequest request)
        {
            if (request == null)
                return new GetUserResponse
                {
                    Success = false,
                    Message = "Error, request nulo"
                };
            User user = _service.Get(request.UserId);
            if (user == null)
                return new GetUserResponse
                {
                    Success = false,
                    Message = "User not found"
                };
            return new GetUserResponse
            {
                Success = true,
                Id = user.Id,
                CreatedDate = user.CreatedDate,
                FirstName = user.FirstName,
                IS = user.IS,
                DateOfBirth = user.DateOfBirth,
                ModifiedDate = user.ModifiedDate,
                LastName = user.LastName,
                Salary = user.Salary
            };

        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest request)
        {
            
            if (request == null)
            {
                return new UpdateUserResponse
                {
                    Success = false,
                    Message = "Error: request is null"
                };
            }
            User user = new User
            {
                Id = request.Id,
                IS = request.IS,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Salary = request.Salary
            };
            if (!_service.Update(user))
            {
                return new UpdateUserResponse
                {
                    Success = false,
                    Message = "Error"
                };
            }
            return new UpdateUserResponse
            {
                Success = true,
                Message = "Done",
                ModifiedDate = DateTime.Now
            };


        }
    }
}
