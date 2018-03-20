using DataAccesEF.Entities;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Helper
{
    public class DataConverter
    {
        public static QuestionType QuestionTypeDTOToEntity(QuestionTypeDTO dtoObject)
        {
            QuestionType result =  new QuestionType
            {
                QuestionTypeId = dtoObject.QestuionTypeId,
                Description = dtoObject.Description,
                CreateDate = dtoObject.CreateDate
            };
            return result;
        }

        public static QuestionTypeDTO QuestionTypeEntityToDTO(QuestionType dtoObject)
        {
            QuestionTypeDTO result = new QuestionTypeDTO
            {
                QestuionTypeId = dtoObject.QuestionTypeId,
                Description = dtoObject.Description,
                CreateDate = dtoObject.CreateDate
            };

            return result;
        }

        public static Question QuestionDTOToEntity(QuestionDTO entity)
        {
            Question result = new Question
            {
                QuestionId = entity.QuestionId,
                Text = entity.Description,
                CreateDate = entity.CreateDate,
                ModifyDate = entity.ModifyDate
            };

            return result;
        }

        public static QuestionDTO QuestionEntityToDTO(Question entity)
        {
            QuestionDTO result = new QuestionDTO
            {
                QuestionId = entity.QuestionId,
                Description = entity.Text,
                CreateDate = entity.CreateDate,
                ModifyDate = entity.ModifyDate
            };

            return result;
        }
    }
}
