using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Business.Contracts
{
    public interface IItemTagService 
    {
        bool AddTagToItem(int itemId, int tagId);
    }
}
