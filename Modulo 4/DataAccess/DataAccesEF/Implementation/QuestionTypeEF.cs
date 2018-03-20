using DataAccesEF.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
using DataAccesEF.Helper;

namespace DataAccesEF.Implementation
{
    public class QuestionTypeEF : IRepository<QuestionTypeDTO>
    {
        public void Add(QuestionTypeDTO entity)
        {
            QuestionType result = DataConverter.QuestionTypeDTOToEntity(entity);

            using (var context = new DemoContext())
            {
                context.QuestionTypes.Add(result);
                context.SaveChanges();
            }
        }

        public int CountItems()
        {
            int count;
            using (var context = new DemoContext())
            {
                count = context.QuestionTypes.Count();
            }
              
            return count;
        }

        public void Delete(int entityId)
        {
            using (var context = new DemoContext())
            {
                var questionType = context.QuestionTypes.Find(entityId);
                context.QuestionTypes.Remove(questionType);
                context.SaveChanges();
            }
        }

        public List<QuestionTypeDTO> GetAll()
        {
            List<QuestionTypeDTO> resultList = new List<QuestionTypeDTO>();
            using (var context = new DemoContext())
            {
                resultList = context.QuestionTypes.Select(s => new QuestionTypeDTO
                {
                    Description = s.Description,
                    QestuionTypeId = s.QuestionTypeId
                }).ToList();
            }
            return resultList;
        }

        public QuestionTypeDTO GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionTypeDTO entity)
        {
            QuestionType result = DataConverter.QuestionTypeDTOToEntity(entity);

            using (var context = new DemoContext())
            {
                var found = context.QuestionTypes.Find(result.QuestionTypeId);
                found.Description = entity.Description;
                context.SaveChanges();
            }
        }
    }
}
