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
        #region QuestionType Converter
        public static QuestionType QuestionTypeDTOToEntity(QuestionTypeDTO dtoObject)
        {
            QuestionType result =  new QuestionType
            {
                QuestionTypeId = dtoObject.QestuionTypeId,
                Description = dtoObject.Description
            };

            return result;
        }

        public static QuestionTypeDTO QuestionTypeEntityToDTO(QuestionType dtoObject)
        {
            QuestionTypeDTO result = new QuestionTypeDTO
            {
                QestuionTypeId = dtoObject.QuestionTypeId,
                Description = dtoObject.Description
            };

            return result;
        }
        #endregion

        #region Question Converter
        public static Question QuestionDTOToEntity(QuestionDTO entity)
        {
            Question result = new Question
            {
                QuestionId = entity.QuestionId,
                Text = entity.Description
            };

            return result;
        }

        public static QuestionDTO QuestionEntityToDTO(Question entity)
        {
            QuestionDTO result = new QuestionDTO
            {
                QuestionId = entity.QuestionId,
                Description = entity.Text
            };

            return result;
        }
        #endregion

        #region Option Converter

        public static OptionDTO OptionEntityToDTO(Option entity)
        {
            OptionDTO optionDTO = new OptionDTO
            {
                Text = entity.Text,
                OptionId = entity.OptionId,
            };

            return optionDTO;
        }

        public static Option OptionDTOToEntity(OptionDTO optiondto)
        {
            Option optionentity = new Option
            {
                Text = optiondto.Text,
                OptionId = optiondto.OptionId
            };

            return optionentity;
        }
        
        #endregion
    }
}
