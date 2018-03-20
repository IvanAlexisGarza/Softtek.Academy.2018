using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IQuestionRepository
    {
        List<QuestionDTO> GetAll();

        QuestionDTO GetById(int entityId);

        void Add(QuestionDTO entity);

        void Update(QuestionDTO entity);

        void Delete(int entityId);

        int CountQuestion();
    }
}
