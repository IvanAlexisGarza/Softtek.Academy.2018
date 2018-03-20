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
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {

        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById([FromUri] int id)
        {
            Question result = _questionService.GetById(id);
            if (result == null)
                return BadRequest("No items match the search parameter");

            QuestionDTO surveyDTO = new QuestionDTO();
            surveyDTO = new QuestionDTO
            {
                Text = result.Text,
                QuestionTypeId = result.QuestionTypeId,
            };

            //var payload = new
            //{
            //    result = surveyDTO
            //};
            return Ok(surveyDTO);
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllQuestions()
        {
            ICollection<Question> result = _questionService.GetAll();
            if (result == null) return BadRequest("No items match the search parameter");
            if (result.Count == 0) return BadRequest("No items match the search parameter");

            ICollection<QuestionDTO> questionDTOList = new List<QuestionDTO>();

            foreach (Question question in result)
            {
                questionDTOList.Add(new QuestionDTO
                {
                    Text = question.Text,
                    QuestionTypeId = question.QuestionTypeId,
                });
            }

            //var payload = new
            //{
            //    results = questionDTOList
            //};
            return Ok(questionDTOList);
        }

        [Route("{questionId:int}/options")]
        [HttpGet]
        public IHttpActionResult GetOptionsByQuestion(int questionId)
        {
            ICollection<Option> result = _questionService.GetOptionsByQuestion(questionId);
            if (result == null) return BadRequest("No items match the search parameter");
            if (result.Count == 0) return BadRequest("No items match the search parameter");

            ICollection<Option> optionList = new List<Option>();

            foreach (Option option in result)
            {
                optionList.Add(new Option
                {
                    Text = option.Text,
                    ScoreValue = option.ScoreValue
                });
            }

            //var payload = new
            //{
            //    results = optionList
            //};
            return Ok(optionList);
        }

        [Route("{questionId:int}/answers")]
        [HttpGet]
        public IHttpActionResult GetAnswersByQuestion(int questionId)
        {
            ICollection<Answer> result = _questionService.GetAnswersByQuestion(questionId);
            if (result == null) return BadRequest("No items match the search parameter");
            if (result.Count == 0) return BadRequest("No items match the search parameter");

            ICollection<Answer> answerList = new List<Answer>();

            foreach (Answer answer in result)
            {
                answerList.Add(new Answer
                {
                    OptionId = answer.OptionId,
                    OpenText = answer.OpenText,
                    //SurveyId = answer.SurveyId,
                });
            }

            //var payload = new
            //{
            //    results = answerList
            //};
            return Ok(answerList);
        }
    }
}