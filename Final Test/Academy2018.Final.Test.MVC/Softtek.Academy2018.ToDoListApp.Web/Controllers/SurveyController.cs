﻿using Newtonsoft.Json;
using Softtek.Academy2018.ToDoListApp.Web.Models;
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
        [HttpGet]
        public ActionResult List()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var result = client.GetAsync("/api/Survey/all");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                List<SurveyDTO> list = JsonConvert.DeserializeObject<List<SurveyDTO>>(data);

                List<SurveyDTO> surveyView = list.Select(q => new SurveyDTO
                {
                    Id = q.Id,
                    Title = q.Title,
                    Description = q.Description,
                    Status = (Status)q.Status
                }).ToList();

                return View(surveyView);
            }
        }

        public ActionResult New(SurveyDTO newSurvey)
        {
            if (newSurvey.Id == 0)
            {
                var createSurvey = new SurveyDTO(); // { Questions = GetQuestions() };
                return View(createSurvey);
            }

            SurveyDTO updateSurvey = Get(newSurvey.Id);
            return View(updateSurvey);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var result = client.GetAsync($"/api/Survey/{id}");
                string data = result.Result.Content.ReadAsStringAsync().Result;
                SurveyDTO survey = JsonConvert.DeserializeObject<SurveyDTO>(data);

                return View(survey);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SurveyDTO survey, string submit)
        {
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

                List<QuestionDTO> list = JsonConvert.DeserializeObject<List<QuestionDTO>>(data);

                return list;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            SurveyDTO surveyView = Get(id);
            return View(surveyView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SurveyDTO survey)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");
            
                var content = new ObjectContent<SurveyDTO>(survey, new JsonMediaTypeFormatter());
            
                var result = client.PutAsync($"/api/survey/{survey.Id}", content).Result;
            }

            return RedirectToAction("List", "Survey");
        }
        
        [HttpPost]
        public async Task<ActionResult> Cancel(SurveyDTO survey, string submit)
        {
            SurveyDTO currentSurvey = Get(survey.Id);

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
        public SurveyDTO Get(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:52217");

                var result = client.GetAsync($"/api/Survey/{id}");

                string data = result.Result.Content.ReadAsStringAsync().Result;

                SurveyDTO survey = JsonConvert.DeserializeObject<SurveyDTO>(data);

                survey.Status = (Status)survey.Status;

                ICollection<QuestionDTO> questionList = GetQuestions(id);

                SurveyDTO surveyView = new SurveyDTO
                {
                    Id = survey.Id,
                    Title = survey.Title,
                    Description = survey.Description,
                    Status = survey.Status,
                    IsActive = survey.IsActive,
                    Questions = questionList
                };
                return surveyView;
            }
        }
    }
}