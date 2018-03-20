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
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public int Create(Tag item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't Create Tag because it's a null value boi !");
                return -1;
            }

            if(_tagRepository.NameExist(item.Name))
            {
                Console.WriteLine("Can't Create Tag because it already exists  boi !");
                return -1;
            }

            return _tagRepository.Create(item);
        }

        public bool Delete(int itemId)
        {
            if (itemId <= 0)
            {
                Console.WriteLine("Can't Delete Tag because it's a null value boi !");
                return false;
            }

            Tag currentTag = _tagRepository.GetById(itemId);

            if(currentTag.Items.Count() >= 0)
            {
                Console.WriteLine("The tag has Items Assigned to it so it can't be deleted");
                return false;
            }

            return _tagRepository.Delete(itemId);
        }

        public Tag GetById(int itemId)
        {
            if (itemId <= 0)
            {
                Console.WriteLine("Can't Get Tag because it's a null value boi !");
                return null;
            }
            return _tagRepository.GetById(itemId);
        }

        public bool IDExist(int itemId)
        {
            return _tagRepository.IDExist(itemId);
        }

        public bool NameExist(string itemName)
        {
            return _tagRepository.NameExist(itemName);
        }

        public bool Update(Tag item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't Update Tag because it's a null value boi !");
                return false;
            }
            return _tagRepository.Update(item);
        }
    }
}
