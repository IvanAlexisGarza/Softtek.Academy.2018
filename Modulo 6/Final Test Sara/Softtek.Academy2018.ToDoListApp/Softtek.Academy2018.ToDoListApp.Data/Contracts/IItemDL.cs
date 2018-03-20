using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface IItemDL
    {
        int CreateItem(Item item);

        Item GetItemById(int id);

        List<Item> SearchItemsbyTitle(string title);

        List<Item> SearchItemsbyRangeDate(DateTime startDate, DateTime endDate);

        bool ArchiveItem(int id);

        List<Item> GetAllItems();

        List<Item> SearchItemsbyTagId(int id);

        bool itemIdExists(int id);

        bool UpdateItem(Item item);
        List<Item> SearchItemsbyStatusId(int id);
        bool AddTagToItem(int itemId, int tagId);
    }
}
