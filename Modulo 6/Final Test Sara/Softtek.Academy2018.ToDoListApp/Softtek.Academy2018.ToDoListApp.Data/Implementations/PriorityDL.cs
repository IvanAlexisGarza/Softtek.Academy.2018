using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using Softtek.Academy2018.ToDoListApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class PriorityDL : IPriorityDL
    {
        public bool priorityIdExist(int priorityId)
        {
            if (priorityId <= 0) return false;

            if (Enum.IsDefined(typeof(Priority), priorityId)) return true;

            else return false;
        }
    }
}
