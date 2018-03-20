using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class ItemDL : IItemDL
    {
        public bool AddTagToItem(int itemId, int tagId)
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    Item item = db.Items.SingleOrDefault(i => i.Id == itemId);
                    if (item == null) return false;

                    Tag tag = db.Tag.SingleOrDefault(t => t.Id == tagId);
                    if (tag == null) return false;

                    item.Tags.Add(tag);
                    db.SaveChanges();

                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ArchiveItem(int id)
        {
            Item item = GetItemById(id);

            if (item == null) return false;

            try
            {
                using (var db = new ToDoListContext())
                {
                    db.Items.Attach(item);
                    db.Entry(item).Property(i => i.IsArchived).CurrentValue = true;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int CreateItem(Item item)
        {
            item.CreatedDate = DateTime.Now;
            item.StatusId = 1;
            try
            {
                using (var db = new ToDoListContext())
                {
                    db.Items.Add(item);
                    db.SaveChanges();
                    return item.Id;
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public List<Item> GetAllItems()
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    return db.Items.Include("Tags")
                                   .Include("Status")
                                   //.OrderByDescending(s => s.PriorityId)
                                   .OrderBy(s => s.DueDate)
                                   .Where(i => i.Status.Description == "Draft" 
                                               || i.Status.Description == "Ready" 
                                               || i.Status.Description == "In Progress")
                                   .ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Item GetItemById(int id)
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    return db.Items.AsNoTracking()
                                   .Where(i => i.IsArchived == false)
                                   .FirstOrDefault(i => i.Id == id);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool itemIdExists(int id)
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    return db.Items.Any(i => i.Id == id);
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Item> SearchItemsbyRangeDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    return db.Items.Where(i => i.IsArchived == false)
                                   .Where(i => i.DueDate >= startDate && i.DueDate <= endDate)
                                   .OrderByDescending(s => s.PriorityId)
                                   .OrderBy(s => s.DueDate)
                                   .ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Item> SearchItemsbyStatusId(int id)
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    return db.Items.Where(i => i.IsArchived == false)
                                   .Where(i => i.StatusId == id)
                                   .OrderByDescending(s => s.PriorityId)
                                   .OrderBy(s=>s.DueDate)
                                   .ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Item> SearchItemsbyTagId(int id)
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                List<Item> list = db.Items
                                    .Where(i => i.IsArchived == false)
                                    .Where(s => s.Id == id)
                                    .OrderByDescending(s => s.PriorityId)
                                    .OrderBy(s => s.DueDate)
                                    .ToList();
                return list;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Item> SearchItemsbyTitle(string title)
        {
            using (var db = new ToDoListContext())
                try
                {
                    {
                        List<Item> list = db.Items
                                            .Where(i => i.IsArchived == false)
                                            .Where(s => s.Title.Contains(title))
                                            .OrderByDescending(s => s.PriorityId)
                                            .OrderBy(s => s.DueDate)
                                            .ToList();
                        return list;
                    }
                }
                catch (Exception)
                {

                    return null;
                }
        }

        public bool UpdateItem(Item item)
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    db.Items.Attach(item);
                    var entry = db.Entry(item);
                    entry.Property(i => i.Title).IsModified = true;
                    entry.Property(i => i.Description).IsModified = true;
                    entry.Property(i => i.ModifiedDate).CurrentValue = DateTime.Today;
                    entry.Property(i => i.StatusId).IsModified = true;
                    entry.Property(i => i.PriorityId).IsModified = true;
                    entry.Property(i => i.DueDate).IsModified = true;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
