using Newtonsoft.Json;
using Softtek.Academy2018.Demo.Data;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Softtek.Academy2018.Demo.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManagementContext _Context;
        public UserClient userClient = new UserClient();

        public UserController()
        {
            _Context = new UserManagementContext();
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            ICollection<User> users = await userClient.GetAll();

            return View(users);
        }

        public ActionResult New()
        {
            return View();
        }

        [Route("User/Save")]
        public ActionResult Save(User user)
        {
            using (var client = new HttpClient())
            {
                Uri uri = new Uri("http://localhost:2311/api/");
                client.BaseAddress = uri;
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(mediaType);//json

                user.IS = "IAGT";
                user.FirstName = "IVAN";
                user.LastName = "GARZA";
                user.DateOfBirth = new DateTime(1994,05,27);
                user.CreatedDate = new DateTime(2018,03,01);
                user.ModifiedDate = new DateTime(2018,03,01);
                user.Salary = 5000;

                //var content = new ObjectContent<User>(user, new JsonMediaTypeFormatter());
                //var result = client.PostAsync("user", content).Result;

                var postTask = client.PostAsJsonAsync<User>("user/add", user);
                postTask.Wait();

                return RedirectToAction("Index", "User");
            }
            //    userClient.Create(user);

            //return RedirectToAction("Index", "User");
        }

        public async Task<ActionResult> Details(int id)
        {
            User user = await userClient.GetById(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }

    public class UserClient
    {
        private readonly Uri uri = new Uri("http://localhost:2311/api/");
        private readonly MediaTypeWithQualityHeaderValue mediaType = new MediaTypeWithQualityHeaderValue("application/json");

        //[HttpPost]
        //public ActionResult Create(User user)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = uri;
        //        //client.DefaultRequestHeaders.Accept.Clear();
        //        //client.DefaultRequestHeaders.Accept.Add(mediaType);//json

        //        user.IS = "IAGT";
        //        user.FirstName = "IVAN";
        //        user.LastName = "GARZA";
        //        user.DateOfBirth = new DateTime(1994 - 05 - 27);
        //        user.CreatedDate = new DateTime(2018 - 03 - 01);
        //        user.ModifiedDate = new DateTime(2018 - 03 - 01);
        //        user.Salary = 5000;

        //        var content = new ObjectContent<User>(user, new JsonMediaTypeFormatter());
        //        var result = client.PostAsync("user", content).Result;


        //        ////HTTP POST
        //        //var postTask = client.PostAsJsonAsync<User>("user", user);
        //        //postTask.Wait();

        //        //var result = postTask.Result;
        //        //if (!result.IsSuccessStatusCode)
        //        //{
        //        //    return false;
        //        //}
        //       // return View("Index");
        //    }
        //}

        public async Task<ICollection<User>> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaType);


                var response = await client.GetAsync("user/all");

                string content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var users = JsonConvert.DeserializeObject<ICollection<User>>(content);

                return users;
            }
        }


        public async Task<User> GetById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaType);

                var response = await client.GetAsync("user/" + id);

                string content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var user = JsonConvert.DeserializeObject<User>(content);

                return user;
            }
        }
    }
}