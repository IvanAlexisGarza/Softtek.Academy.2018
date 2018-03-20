using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface ITagDL
    {
        bool TagIdExist(int id);
        Tag GetTagById(int id);
        int CreateTag(Tag tag);
        bool ArchiveTag(int id);
        List<Tag> GetAllTags();
        bool UpdateTag(Tag tag);
    }
}
