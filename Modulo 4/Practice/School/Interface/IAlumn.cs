using DTOPro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IAlumn
    {

        List<AlumnDTO> GetAll();
        AlumnDTO GetId();
        void AddAlumnDTO(AlumnDTO entity);
        void UpdateAlumnDTO(AlumnDTO entity);
        void Delete(int AlumnId);

    }
}

