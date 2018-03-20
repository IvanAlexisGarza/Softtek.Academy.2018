using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class ItemRepository : IItemRepository
    {
        public bool Activate(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't Activate Item because it's a null value boi !");
                return false;
            }
            using (var context = new ToDoListContext())
            {
                Item currentItem = context.Items.AsNoTracking().SingleOrDefault(x => x.Id == item.Id);

                currentItem.IsArchived = false;
                currentItem.ModifiedDate = DateTime.Now;
                context.SaveChanges();
                return true;
            }
        }

        public bool AddTag(int itemId, int tagId)
        {
            using (var context = new ToDoListContext())
            {
                Item currentItem = context.Items.SingleOrDefault(x => x.Id == itemId);
                if (currentItem == null) return false;

                Tag currentTag = context.Tags.SingleOrDefault(x => x.Id == tagId);
                if (currentTag == null) return false;

                currentItem.Tags.Add(currentTag);
                context.SaveChanges();

                return true;
            }
        }

        public int Create(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't add Item because it's a null value boi !");
                return -1;
            }

            using (var context = new ToDoListContext())
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                item.IsArchived = false;
                context.Items.Add(item);
                context.SaveChanges();
                return item.Id;
            }
        }

        public bool Delete(int itemId)
        {
            if (itemId <= 0)
            {
                Console.WriteLine("ItemId is smaller than 0, how am i going to delete it? Honestly they want me to do everything around this house ");
                return false;
            }
            using (var context = new ToDoListContext())
            {
                Item currentItem = context.Items.AsNoTracking().SingleOrDefault(x => x.Id == itemId);

                currentItem.IsArchived = true;
                currentItem.ModifiedDate = DateTime.Now;
                context.SaveChanges();
                return true;
            }
        }

        public Item GetById(int itemId)
        {
            using (var context = new ToDoListContext())
            {
                return context.Items.AsNoTracking().SingleOrDefault(x => x.Id == itemId);
            }
        }

        public ICollection<Item> GetByPriority(int priorityId)
        {
            using (var context = new ToDoListContext())
            {
                IList<Item> resultList = context.Items.Where(x => x.PriorityId == priorityId).ToList();

                return resultList;
            }
        }

        public bool IDExist(int itemId)
        {
            using (var context = new ToDoListContext())
            {
                return context.Items.Any(x => x.Id == itemId);
            }
        }

        public bool NameExist(string itemName)
        {
            using (var context = new ToDoListContext())
            {
                return context.Items.Any(x => x.Title == itemName);
            }
        }

        public bool Update(Item item)
        {
            using (var context = new ToDoListContext())
            {
                Item currentItem = context.Items.SingleOrDefault(x => x.Id == item.Id);

                if (currentItem == null) return false;

                currentItem.Id = item.Id;
                currentItem.PriorityId = item.PriorityId;
                currentItem.StatusId = item.StatusId;
                currentItem.Status = item.Status;
                currentItem.ModifiedDate = DateTime.Now;
                currentItem.IsArchived = item.IsArchived;

                context.SaveChanges();

                return true;
            }
        }
    }
}
