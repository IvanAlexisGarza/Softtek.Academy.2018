using Softtek.Academia2018.ToDoListApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softte.Academy2018.ToDoListApp.Client.Contracts
{
    public interface IItemClient
    {
        Task<ItemDTO> GetItembyId(int id);
        Task<ICollection<ItemDTO>> GetAllItems();
        Task<bool> AddItem(ItemDTO itemDTO);
        Task<bool> UpdateItem(ItemDTO itemDTO);
    }
}
