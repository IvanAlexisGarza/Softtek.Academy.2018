using Academy2018.Final.Test.Business.Contracts;
using Academy2018.Final.Test.V2.Domain.Model;
using Academy2018.Final.Test.V2.WebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Academy2018.Final.Test.V2.WebAPI2.Controllers
{
    [RoutePrefix("api/Survey")]
    public class SurveyController : ApiController
    {

        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById([FromUri] int id)
        {
            Survey result = _surveyService.GetById(id);
            if (result == null)
                return BadRequest("No items match the search parameter");

            SurveyDTO surveyDTO = new SurveyDTO();
            surveyDTO = new SurveyDTO
            {
                Title = result.Title,
                Description = result.Description,
                IsActive = result.IsActive
            };

            //var payload = new
            //{
            //    result = surveyDTO
            //};
            return Ok(surveyDTO);
        }

        [Route("{id:int}/allquestions")]
        [HttpGet]
        public IHttpActionResult GetQuestionsBySurvey([FromUri] int id)
        {
            ICollection<Question> questionList = _surveyService.GetQuestionsBySurvey(id);
            if (questionList == null)
                return BadRequest("No items match the search parameter");

            List<QuestionDTO> questionDTOList = new List<QuestionDTO>();

            foreach (var question in questionList)
            {
                questionDTOList.Add( new QuestionDTO
                {
                    Id = question.Id,
                    Text = question.Text,
                    QuestionTypeId = question.QuestionTypeId,
                });
            }

            //var payload = new { question = questionDTOList };

            //return Ok(payload);

            return Ok(questionDTOList);
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ICollection<Survey> result = _surveyService.GetAll();
            if (result == null) return BadRequest("No items match the search parameter");
            if (result.Count == 0) return BadRequest("No items match the search parameter");

            ICollection<SurveyDTO> surveyDTOList = new List<SurveyDTO>();

            foreach (Survey survey in result)
            {
                surveyDTOList.Add(new SurveyDTO
                {
                    StatusId = survey.StatusId,
                    Title = survey.Title,
                    Description = survey.Description,
                    IsActive = survey.IsActive,
                });
            }

            return Ok(surveyDTOList);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] SurveyDTO surveyDTO)
        {
            if (surveyDTO == null) return BadRequest("Request is null");

            Survey survey = new Survey
            {
                Title = surveyDTO.Title,
                Description = surveyDTO.Description,
                IsActive = surveyDTO.IsActive,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            int id = _surveyService.Create(survey);

            if (id <= 0) return BadRequest("Unable to create user");

            var payload = new { SurveyId = id };

            return Ok(payload);
        }

        [Route("{surveyId:int}/question/{questionId:int}")]
        [HttpPut]
        public IHttpActionResult AddQuestionToSurvey([FromUri]int surveyId, [FromUri] int questionId)
        {
            bool asignacion = _surveyService.AddQuestion(questionId, surveyId);
            if (!asignacion)
                return BadRequest("Unable to add Question");

            var payload = new
            {
                question = questionId,
                survey = surveyId
            };

            return Ok(payload);
        }

        [Route("{surveyId:int}/status/{statusId:int}")]
        [HttpPut]
        public IHttpActionResult ChangeStatus([FromUri]int surveyId, [FromUri] int statusId)
        {
            bool asignacion = _surveyService.ChangeStatus(surveyId, statusId);
            if (!asignacion)
                return BadRequest("Unable to change status, remember you can't change the status of a survey in done or cancelled status or change the status from draft to ready");

            var payload = new
            {
                Survey = surveyId,
                Status = statusId
            };
            return Ok(payload);
        }

        [Route("{surveyId:int}/active/{activeState:int}")]
        [HttpPut]
        public IHttpActionResult ActiveStateChange([FromUri]int surveyId, [FromUri] int activeState)
        {
            bool asignacion = false;

            if (activeState == 1)
            {
                asignacion = _surveyService.ActivateSurvey(surveyId);
            }

            if (activeState == 0)
            {
                asignacion = _surveyService.DeactivateSurvey(surveyId);
            }

            if (!asignacion)
                return BadRequest("Unable to change status, remember you can't change the status of a survey in done or cancelled status or change the status from draft to ready");

            var payload = new
            {
                Survey = surveyId,
                StateChanged = asignacion
            };
            return Ok(payload);
        }
    }
}