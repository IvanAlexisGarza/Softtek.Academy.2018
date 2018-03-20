using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Data.Implementations
{
    public class TagDL : ITagDL
    {
        public bool ArchiveTag(int id)
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    Tag tag =db.Tag.FirstOrDefault(t => t.Id == id);
                    db.Tag.Attach(tag);
                    db.Entry(tag).Property(t => t.IsActive).CurrentValue = false;
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int CreateTag(Tag tag)
        {
            tag.CreatedDate = DateTime.Now;
            tag.IsActive = true;
            try
            {
                using (var db = new ToDoListContext())
                {
                    db.Tag.Add(tag);
                    db.SaveChanges();
                    return tag.Id;
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public List<Tag> GetAllTags()
        {
            try
            {
                using (var db = new ToDoListContext())
                {
                    return db.Tag.Where(t => t.IsActive == true).ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Tag GetTagById(int id)
        {
            if (id <= 0) return null;

            try
            {
                using (var db = new ToDoListContext())
                {
                    return db.Tag.FirstOrDefault(t=>t.Id == id);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool TagIdExist(int id)
        {
            try
            {
                if (id <= 0) return false;

                using (var db = new ToDoListContext())
                {
                    return db.Tag.Any(t => t.Id == id);
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateTag(Tag tag)
        {
            try
            {
                //if (tag.Id <= 0) return false;
                using (var db = new ToDoListContext())
                {
                    //Tag oldTag = db.Tag.FirstOrDefault(t => t.Id == tag.Id);

                    //if (oldTag == null) return false;

                    db.Tag.Attach(tag);
                    var entry = db.Entry(tag);
                    entry.Property(t => t.Name).IsModified = true;
                    entry.Property(t => t.ModifiedDate).CurrentValue = DateTime.Today;
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
