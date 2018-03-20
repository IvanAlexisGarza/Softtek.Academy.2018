using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Business.Contracts
{
    public interface IItemBL
    {
        int CreateItem(Item item);

        bool UpdateItem(Item item);

        Item GetItemById(int id);

        List<Item> GetAllItems();

        List<Item> SearchItemsbyStatusId(int id);

        List<Item> SearchItemsbyTagId(int id);

        List<Item> SearchItemsbyTitle(string title);

        List<Item> SearchItemsbyRangeDate(DateTime startDate, DateTime endDate);

        bool ArchiveItem(int id);

        bool AddTagToItem(int itemId, int tagId);

        /*int TagsbyItemId(int itemId);

        TagDTO SearchTagbyName(string tagName);

        void AddTagstoItem(int ItemId, string[] tags);

        int CountItemsbyTagId(int tagId, bool countArchivedItems);*/
    }
}
