using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using Softtek.Academy2018.ToDoListApp.Data.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Business.Implementations
{
    public class ItemBL : IItemBL
    {
        private readonly IItemDL itemDL;
        private readonly IStatusDL statusDL = new StatusDL();
        private readonly ITagDL tagDL = new TagDL();
        private readonly IPriorityDL priorityDL = new PriorityDL();

        public ItemBL(IItemDL itemRepository)
        {
            itemDL = itemRepository;
        }

        public bool AddTagToItem(int itemId, int tagId)
        {
            if (itemId <= 0 || tagId <= 0) return false;

            bool itemIdExists = itemDL.itemIdExists(itemId);

            bool tagIdExists = tagDL.TagIdExist(tagId);

            if (!tagIdExists || !itemIdExists) return false;

            return itemDL.AddTagToItem(itemId, tagId);
        }

        public bool ArchiveItem(int id)
        {
            if (id <= 0) return false;

            Item item = itemDL.GetItemById(id);

            if (item == null || item.IsArchived) return false;

            return itemDL.ArchiveItem(id);
        }

        public int CreateItem(Item item)
        {
            if (item.Id != 0) return 0;

            if (string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.Description)) return 0;

            if ((item.CreatedDate != default(DateTime)) == (item.CreatedDate != null)) return 0;

            if ((item.ModifiedDate != default(DateTime)) == (item.ModifiedDate != null)) return 0;

            if (item.DueDate < DateTime.Now) return 0;

            //if (item.PriorityId != 0) return 0;

            //if (item.StatusId <= 0) return 0;

            //bool statusIdExist = statusDL.StatusIdExist(item.StatusId);

            //if (!statusIdExist) return 0;

            int id = itemDL.CreateItem(item);

            return id;
        }

        public List<Item> GetAllItems()
        {
            return itemDL.GetAllItems();
        }

        public Item GetItemById(int id)
        {
            if (id <= 0) return null;

            Item item = itemDL.GetItemById(id);

            if (item != null && item.IsArchived) return null;

            return item;
        }

        public List<Item> SearchItemsbyRangeDate(DateTime startDate, DateTime endDate)
        {
            if (startDate == null) return null;

            if (endDate == null) return null;

            return itemDL.SearchItemsbyRangeDate(startDate, endDate);
        }

        public List<Item> SearchItemsbyStatusId(int id)
        {
            if (id <= 0) return null;

            bool statusIdExist = statusDL.StatusIdExist(id);

            if (!statusIdExist) return null;

            List<Item> items = itemDL.SearchItemsbyStatusId(id);

            return items;
        }

        public List<Item> SearchItemsbyTagId(int id)
        {
            if (id <= 0) return null;

            bool tagIdExist = tagDL.TagIdExist(id);

            if (!tagIdExist) return null;

            List<Item> items = itemDL.SearchItemsbyTagId(id);

            return items;
        }

        public List<Item> SearchItemsbyTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return null;

            return itemDL.SearchItemsbyTitle(title);
        }

        public bool UpdateItem(Item item)
        {

            if (item.Id <= 0) return false;

            bool idExist = itemDL.itemIdExists(item.Id);

            if (!idExist) return false;

            if (string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.Description)) return false;

            if (item.DueDate < DateTime.Now) return false;

            //if (item.PriorityId <= 0) return false;

            //bool priorityIdExist = priorityDL.priorityIdExist(item.PriorityId);

            //if (!priorityIdExist) return false;

            //if (item.StatusId <= 0) return false;

            //bool statusIdExist = statusDL.StatusIdExist(item.StatusId);

            //if (!statusIdExist) return false;

            bool isUpdated = itemDL.UpdateItem(item);

            return isUpdated;
        }
    }
}
