using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Business.Implementations
{
    public class ItemTagService : IItemTagService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ITagRepository _tagRepository;

        public ItemTagService(IItemRepository itemRepository, ITagRepository tagRepository)
        {
            _itemRepository = itemRepository;
            _tagRepository = tagRepository;
        }

        public bool AddTagToItem(int itemId, int tagId)
        {
            Item currentItem = _itemRepository.GetById(itemId);
            Tag currentTag = _tagRepository.GetById(tagId);

            if (currentItem.Tags.Count() >= 10)
            {
                Console.WriteLine("This Task already has ten Tags boi !");
                return false;
            }

            bool itemExist = _itemRepository.IDExist(itemId);
            if (!itemExist) return false;

            bool tagExist = _tagRepository.IDExist(tagId);
            if (!tagExist) return false;

            return _itemRepository.AddTag(itemId, tagId);

        }

        public int ItemTagCount(int itemId)
        {

            bool itemExist = _itemRepository.IDExist(itemId);
            if (!itemExist)
            {
                Console.WriteLine("Item dosen't even exist man");
                return -1;
            }

            Item currentItem = _itemRepository.GetById(itemId);
            return currentItem.Tags.Count();
        }
    }
}
