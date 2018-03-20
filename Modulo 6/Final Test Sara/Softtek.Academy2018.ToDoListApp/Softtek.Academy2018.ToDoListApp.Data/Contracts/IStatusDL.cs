using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface IStatusDL
    {
        bool StatusIdExist(int statusId);
    }
}
