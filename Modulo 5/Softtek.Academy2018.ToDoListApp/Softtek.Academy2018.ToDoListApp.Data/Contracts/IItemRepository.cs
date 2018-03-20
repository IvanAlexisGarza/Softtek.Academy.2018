using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface IItemRepository : IGenericRepository<Item>
    {
         bool Activate(Item item);

        bool AddTag(int itemId, int tagId);

        ICollection<Item> GetByPriority(int priorityId);
    }
}
