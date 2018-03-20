using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class TagRepository : ITagRepository
    {
        public int Create(Tag item)
        {
            if (item == null)
            {
                Console.WriteLine("SERIOUSLY? This is null, how am i going to create it? Honestly they want me to do everything around this house !");
                return -1;
            }

            using (var context = new ToDoListContext())
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                item.IsActive = true;
                context.Tags.Add(item);
                context.SaveChanges();
                return item.Id;
            }
        }

        public bool Delete(int itemId)
        {
            if (itemId <= 0)
            {
                Console.WriteLine("This is smaller than 0, how am i going to delete it? Honestly they want me to do everything around this house ");
                return false;
            }
            using (var context = new ToDoListContext())
            {
                Tag currentTag = context.Tags.AsNoTracking().SingleOrDefault(x => x.Id == itemId);

                context.Tags.Remove(currentTag);
                context.SaveChanges();
                return true;
            }
        }


        public Tag GetById(int itemId)
        {
            using (var context = new ToDoListContext())
            {
                return context.Tags.AsNoTracking().SingleOrDefault(x => x.Id == itemId);
            }
        }

        public bool IDExist(int itemId)
        {
            using (var context = new ToDoListContext())
            {
                return context.Tags.Any(x => x.Id == itemId);
            }
        }

        public bool NameExist(string itemName)
        {
            using (var context = new ToDoListContext())
            {
                return context.Tags.Any(x => x.Name == itemName);
            }
        }

        public bool Update(Tag item)
        {
            using (var context = new ToDoListContext())
            {
                Tag currentTag = context.Tags.SingleOrDefault(x => x.Id == item.Id);

                if (currentTag == null) return false;

                currentTag.Id = item.Id;
                currentTag.IsActive = item.IsActive;
                currentTag.Items = item.Items;
                currentTag.Name = item.Name;

                currentTag.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }
    }
}
