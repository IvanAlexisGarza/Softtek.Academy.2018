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
    [RoutePrefix("api/answer")]
    public class AnswerController : ApiController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [Route("{answerId:int}/question/{questionId:int}")]
        [HttpPut]
        public IHttpActionResult AddAnswerToQuestion([FromUri]int answerId, [FromUri] int questionId)
        {
            bool asignacion = _answerService.AddAnswerToQuestion(answerId, questionId);
            if (!asignacion)
                return BadRequest("Unable to add Question");

            var payload = new
            {
                question = questionId,
                answer = answerId
            };

            return Ok(payload);
        }




        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateAnswer([FromBody] AnswerDTO answerDTO)
        {
            if (answerDTO == null) return BadRequest("Request is null");

            Answer answer = new Answer
            {
                QuestionId = answerDTO.QuestionId,
                OptionId = answerDTO.OptionId,
                SurveyId = answerDTO.SurveyId,
            };

            int id = _answerService.CreateAnswer(answer);

            if (id <= 0) return BadRequest("Unable to create user");

            var payload = new { answerId = id };

            return Ok(payload);
        }
    }
}
