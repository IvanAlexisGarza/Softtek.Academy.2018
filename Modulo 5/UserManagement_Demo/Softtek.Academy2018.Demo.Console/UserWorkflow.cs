using Softtek.Academy2018.Demo.Console.UserManagementService_Ref;
using System;

namespace Softtek.Academy2018.Demo.Console
{
    public class UserWorkflow
    {
        private readonly UserManagementServiceClient _client;

        public UserWorkflow(UserManagementServiceClient client)
        {
            _client = client;
        }

        public void CreateUser()
        {
            System.Console.WriteLine("---Create new user---");

            System.Console.Write("IS:");
            string IS = System.Console.ReadLine();
            System.Console.Write("First Name:");
            string firstName = System.Console.ReadLine();
            System.Console.Write("Last Name:");
            string lastName = System.Console.ReadLine();
            System.Console.Write("Date of Birth (MM/DD/YYYY):");
            DateTime dateOfBirth = DateTime.Parse(System.Console.ReadLine());
            System.Console.Write("Salary:");
            double salary = double.Parse(System.Console.ReadLine());

            CreateUserRequest request = new CreateUserRequest
            {
                IS = IS,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Salary = salary
            };

            CreateUserResponse response = null;

            response = _client.CreateUser(request);

            if (response == null)
            {
                System.Console.WriteLine("Error: Response is null");
            }
            else
                if (!response.Success || response.UserId <= 0)
            {
                System.Console.WriteLine($"Error: { response.Message}");
            }
            else
            {
                System.Console.WriteLine($"Success: User created, Id: {response.UserId}");
            }

            System.Console.WriteLine("------------------");
        }

        public void ReadUser()
        {
            System.Console.WriteLine("---View user---");

            System.Console.Write("Id:");
            int id = int.Parse(System.Console.ReadLine());

            GetUserRequest request = new GetUserRequest
            {
                UserId = id
            };

            GetUserResponse response = _client.GetUser(request);

            if (response == null)
            {
                System.Console.WriteLine("Error: Response is null");
            }
            else
                if (!response.Success)
            {
                System.Console.WriteLine($"Error: {response.Message}");
            }
            else
            {
                System.Console.WriteLine("Success: User found");
                System.Console.WriteLine($"IS:{response.IS}");
                System.Console.WriteLine($"First Name:{response.FirstName}");
                System.Console.WriteLine($"Last Name:{response.LastName}");
                System.Console.WriteLine($"Date of Birth:{response.DateOfBirth.Value.ToString("MM/dd/yyyy")}");
                System.Console.WriteLine($"Salary:{response.Salary}");
                System.Console.WriteLine($"Created date:{response.CreatedDate}");
                System.Console.WriteLine($"Modified date:{(response.ModifiedDate.HasValue ? response.ModifiedDate.Value.ToString() : string.Empty)}");
            }

            System.Console.WriteLine("------------------");
        }

        public void UpdateUser()
        {
            System.Console.WriteLine("---Update user---");

            System.Console.Write("Id:");
            int id = int.Parse(System.Console.ReadLine());

            GetUserRequest requestGet = new GetUserRequest
            {
                UserId = id
            };

            GetUserResponse responseGet = _client.GetUser(requestGet);

            if (responseGet == null)
            {
                System.Console.WriteLine("Error: response is null");
                return;
            }

            if (!responseGet.Success)
            {
                System.Console.WriteLine($"Error: {responseGet.Message}");
                return;
            }

            UpdateUserRequest requestUpdate = new UpdateUserRequest
            {
                Id = responseGet.Id,
                IS = responseGet.IS,
                FirstName = responseGet.FirstName,
                LastName = responseGet.LastName,
                DateOfBirth = responseGet.DateOfBirth,
                Salary = responseGet.Salary
            };

            System.Console.WriteLine("Success: User found");
            System.Console.WriteLine($"IS:{requestUpdate.IS}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New IS:");
                requestUpdate.IS = System.Console.ReadLine();
            }

            System.Console.WriteLine($"First Name:{requestUpdate.FirstName}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New First Name:");
                requestUpdate.FirstName = System.Console.ReadLine();
            }

            System.Console.WriteLine($"Last Name:{requestUpdate.LastName}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New Last Name:");
                requestUpdate.LastName = System.Console.ReadLine();
            }

            System.Console.WriteLine($"Date of Birth:{requestUpdate.DateOfBirth.Value.ToString("MM/dd/yyyy")}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New Date of Birth:");
                requestUpdate.DateOfBirth = DateTime.Parse(System.Console.ReadLine());
            }

            System.Console.WriteLine($"Salary:{requestUpdate.Salary}");
            System.Console.WriteLine("Press [ESC] to skip");
            if (System.Console.ReadKey(true).Key != System.ConsoleKey.Escape)
            {
                System.Console.Write("New Salary:");
                requestUpdate.Salary = double.Parse(System.Console.ReadLine());
            }

            UpdateUserResponse responseUpdate = _client.UpdateUser(requestUpdate);

            if (responseUpdate == null)
            {
                System.Console.WriteLine("Error: response is null");
            }
            else
            if (!responseUpdate.Success)
            {
                System.Console.WriteLine($"Error: {responseUpdate.Message}");
            }
            else
            {
                System.Console.WriteLine($"Success: User updated");
            }

            System.Console.WriteLine("------------------");
        }

        public void Delete()
        {
            System.Console.WriteLine("---Delete user---");

            System.Console.Write("Id:");
            int id = int.Parse(System.Console.ReadLine());

            GetUserRequest requestGet = new GetUserRequest
            {
                UserId = id
            };

            GetUserResponse responseGet = _client.GetUser(requestGet);

            if (responseGet == null)
            {
                System.Console.WriteLine("Error: response is null");
                return;
            }

            if (!responseGet.Success)
            {
                System.Console.WriteLine($"Error: {responseGet.Message}");
                return;
            }

            System.Console.WriteLine("Success: User found");

            System.Console.WriteLine("Do you want to delete the user?[Y/n]");

            if (System.Console.ReadKey(true).Key == System.ConsoleKey.Y)
            {
                DeleteUserRequest requestDelete = new DeleteUserRequest
                {
                    UserId = id
                };

                DeleteUserResponse responseDelete = _client.DeleteUser(requestDelete);

                if (responseDelete == null)
                {
                    System.Console.WriteLine("Error: response is null");
                }
                else
                if (!responseDelete.Success)
                {
                    System.Console.WriteLine($"Error: {responseDelete.Message}");
                }
                else
                {
                    System.Console.WriteLine($"Success: User deleted");
                }
            }

            System.Console.WriteLine("------------------");
        }
    }
}
