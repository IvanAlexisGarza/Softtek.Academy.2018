using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
using DataAccesEF.Entities;
using DataAccesEF.Helper;

namespace DataAccesEF.Implementation
{
    public class QuestionEF : IQuestionRepository
    {
        public void Add(QuestionDTO entity)
        {
            Question result = DataConverter.QuestionDTOToEntity(entity);

            using (var context = new DemoContext())
            {
                context.Questions.Add(result);
                context.SaveChanges();
            }
        }

        public int CountQuestion()
        {
            int count;

            using (var context = new DemoContext())
            {
               count = context.Questions.Count();
            }
            return count;
        }

        public void Delete(int entityId)
        {
            using (var context = new DemoContext())
            {
                var question = context.Questions.Find(entityId);
                context.Questions.Remove(question);
                context.SaveChanges();
            }
        }

        public List<QuestionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public QuestionDTO GetById(int entityid)
        {
            QuestionDTO dtoObj = new QuestionDTO();

            using (var context = new DemoContext())
            {
                //Forma query
                var result = from question in context.Questions
                             where question.QuestionId == entityid
                             select question;

                //Use Data Converter
                //dtoObj = result.FirstOrDefault<QuestionDTO>();

                //Formna metodo
                //var result = context.Questions.Find(entityid);
            }

            return dtoObj;
        }

        public void Update(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }

        //Unfinished
        public List<OptionDTO> GetOptionByQuestionId(int questionId)
        {
            List<OptionDTO> optionDTO = new List<OptionDTO>;

            quey = from cosa in Context.option

        }
    }
}
