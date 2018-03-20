using Newtonsoft.Json;
using Softtek.Academy2018.ToDoListApp.Web.Models;
using Softtek.Academy2018.ToDoListApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Softtek.Academy2018.ToDoListApp.Web.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Item
        [HttpGet]
        public ActionResult List()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var result = client.GetAsync("/api/Survey/all");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                List<SurveyDTO> list = JsonConvert.DeserializeObject<List<SurveyDTO>>(data);


                List<SurveyViewModel> surveyView = list.Select(q => new SurveyViewModel
                {
                    Id = q.Id,
                    Title = q.Title,
                    Description = q.Description,
                    StatusId = q.StatusId,
                    Status = (Status)q.StatusId
                }).ToList();

                return View(surveyView);
            }
        }

        public ActionResult Delete(SurveyViewModel survey)
        {
            return View(survey);
        }

        public ActionResult New(SurveyViewModel newSurvey)
        {
            if (newSurvey.Id == 0)
            {
                var createSurvey = new SurveyViewModel() ;// { Questions = GetQuestions() };
                return View(createSurvey);
            }

            SurveyViewModel updateSurvey = Get(newSurvey.Id);
            updateSurvey.Questions = GetQuestions(updateSurvey.Id);
            updateSurvey.Action = "Update";

            return View(updateSurvey);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SurveyDTO survey, string submit)
        {
            switch (submit)
            {
                case "draft":
                    survey.StatusId = 1;
                    break;
                case "ready":
                    survey.StatusId = 2;
                    break;
            }

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var content = new ObjectContent<SurveyDTO>(survey, new JsonMediaTypeFormatter());

                var result = client.PostAsync("/api/Survey", content).Result;

                return RedirectToAction("List", "Survey");
            }
        }

        public ICollection<QuestionDTO> GetQuestions(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var result = client.GetAsync($"/api/Survey/{id}/allquestions");

                string data = result.Result.Content.ReadAsStringAsync().Result;
                //data = data.Remove(0, data.IndexOf('{'));

                //var response = JsonConvert.DeserializeObject<List<QuestionList>>(data);

                var resultado = JsonConvert.DeserializeObject<QuestionList>(data);



                ICollection<QuestionDTO> questionList = new List<QuestionDTO>();

                QuestionDTO question = new QuestionDTO
                {
                    Text = resultado.Question[0].Text,
                    Id = resultado.Question[0].Id,
                    QuestionTypeId = resultado.Question[0].QuestionTypeId
                };


                questionList.Add(question);

                //JavaScriptSerializer ser = new JavaScriptSerializer();

                //var response = new ser.Deserialize<List<QuestionList>>(data);

                //List<QuestionDTO> list = alllist.Where(x => x.IsActive == true).ToList();

                return questionList;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            SurveyViewModel surveyView = Get(id);
            return View(surveyView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SurveyDTO survey)
        {
            int id = survey.Id;

            if (survey.Status==Status.Done)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52217");

                    var content = new ObjectContent<SurveyDTO>(survey, new JsonMediaTypeFormatter());

                    var result = client.PutAsync($"/api/survey/{id}", content).Result;
                } 
            }
            return RedirectToAction("List", "Survey");
        }
        
        [HttpPost]
        public async Task<ActionResult> Cancel(SurveyViewModel survey, string submit)
        {
            SurveyViewModel currentSurvey = Get(survey.Id);

            if (submit=="yes" && survey.Status!=Status.Done)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52217");

                    var result = await client.DeleteAsync($"/api/survey/{survey.Id}");
                } 
            }

            return RedirectToAction("List", "Survey");
        }

        [HttpGet]
        public SurveyViewModel Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var result = client.GetAsync($"/api/Survey/{id}");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                SurveyDTO survey = JsonConvert.DeserializeObject<SurveyDTO>(data);

                survey.Status = (Status)survey.StatusId;

                //ICollection<QuestionDTO> questionList = GetQuestions(id);

                SurveyViewModel surveyView = new SurveyViewModel
                {
                    Id = survey.Id,
                    Title = survey.Title,
                    Description = survey.Description,
                    Status = survey.Status,
                    IsActive = survey.IsActive,
                   // Questions = questionList
                };

                

                return surveyView;
            }
        }

    }
}