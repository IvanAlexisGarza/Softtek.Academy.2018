using Newtonsoft.Json;
using Softtek.Academy2018.ToDoListApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace Softtek.Academy2018.ToDoListApp.Web.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult List()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var result = client.GetAsync("/api/question/all");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                List<QuestionDTO> list = JsonConvert.DeserializeObject<List<QuestionDTO>>(data);

                return View(list);
            }
        }

        public ActionResult New(QuestionDTO question)
        {
            QuestionDTO newQuestion = Get(question.Id);
            return View(newQuestion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(QuestionDTO question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var content = new ObjectContent<QuestionDTO>(question, new JsonMediaTypeFormatter());

                var result = client.PostAsync("/api/question", content).Result;

                return RedirectToAction("List", "Question");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(QuestionDTO question)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var content = new ObjectContent<QuestionDTO>(question, new JsonMediaTypeFormatter());

                var result = client.PutAsync($"/api/question/{question.Id}", content).Result;

                return RedirectToAction("List", "Question");
            }
        }

        [HttpGet]
        public QuestionDTO Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var result = client.GetAsync($"/api/question/{id}");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                QuestionDTO question = JsonConvert.DeserializeObject<QuestionDTO>(data);

                return question;
            }
        }
    }
}