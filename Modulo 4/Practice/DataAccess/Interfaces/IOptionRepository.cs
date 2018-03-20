using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IOptionRepository
    {
        List<OptionDTO> GetAll();

        OptionDTO GetById(int entityid);

        void Add(OptionDTO entity);

        void Update(OptionDTO entity);

        void Delete(int entityId);

        int CountQuestion();
    }
}
