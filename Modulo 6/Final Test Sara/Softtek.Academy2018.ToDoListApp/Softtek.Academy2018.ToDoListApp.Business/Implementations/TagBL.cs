using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Business.Implementations
{
    public class TagBL : ITagBL
    {
        private readonly ITagDL tagDL;

        public TagBL(ITagDL itemRepository)
        {
            tagDL = itemRepository;
        }

        public Tag GetTagById(int id)
        {
            if (id <= 0) return null;

            bool exists = tagDL.TagIdExist(id);

            if (!exists) return null;

            return tagDL.GetTagById(id);
        }

        public int CreateTag(Tag tag)
        {
            if (tag.Id != 0) return 0;

            if (string.IsNullOrEmpty(tag.Name)) return 0;

            if ((tag.CreatedDate != default(DateTime)) == (tag.CreatedDate != null)) return 0;

            if ((tag.ModifiedDate != default(DateTime)) == (tag.ModifiedDate != null)) return 0;

            int id = tagDL.CreateTag(tag);

            return id;
        }

        public bool ArchiveTag(int id)
        {
            if (id <= 0) return false;

            bool exists = tagDL.TagIdExist(id);

            if (!exists) return false;

            return tagDL.ArchiveTag(id);
        }

        public List<Tag> GetAllTags()
        {
            return tagDL.GetAllTags();
        }

        public bool UpdateTag(Tag tag)
        {
            if (tag.Id <= 0) return false;

            bool idExists = tagDL.TagIdExist(tag.Id);

            if (!idExists) return false;

            if (string.IsNullOrEmpty(tag.Name)) return false;

            if (tag.CreatedDate == null) return false;

            bool updated = tagDL.UpdateTag(tag);

            if (!updated) return false;

            return true;
        }
    }
}
