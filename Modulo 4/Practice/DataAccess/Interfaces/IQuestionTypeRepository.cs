using DataAccess.DTO;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IQuestionTypeRepository
    {
        List<QuestionTypeDTO> GetAll();

        QuestionTypeDTO GetById(int entityid);

        void Add(QuestionTypeDTO entity);

        void Update(QuestionTypeDTO entity);

        void Delete(int entityId);

        int CountQuestionType();
    }
}
