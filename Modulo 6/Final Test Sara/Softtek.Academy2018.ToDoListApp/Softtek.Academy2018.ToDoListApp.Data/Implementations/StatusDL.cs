using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class StatusDL : IStatusDL
    {
        public bool StatusIdExist(int statusId)
        {
            if (statusId <= 0) return false;

            try
            {
                using (var db = new ToDoListContext())
                {
                    return db.Status.Any(s => s.Id == statusId);
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
