using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using Softtek.Academy2018.ToDoListApp.Data.Contracts;


namespace Softtek.Academy2018.ToDoListApp.Business.Implementations
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository, ITagRepository tagRepository)
        {
            _itemRepository = itemRepository;
        }

        public int Create(Item item)
        {
            if(item == null)
            {
                Console.WriteLine("Can't Create Item because it's a null value boi !");
                return -1;
            }

            return _itemRepository.Create(item);
        }

        public bool Delete(int itemId)
        {
            if (itemId <= 0)
            {
                Console.WriteLine("Can't Delete Item because it's a null value boi !");
                return false;
            }
            return _itemRepository.Delete(itemId);
        }

        public ICollection<Item> GetByPriority(int priorityId)
        {
            return _itemRepository.GetByPriority(priorityId);
        }

        public Item GetById(int itemId)
        {
            if (itemId <= 0)
            {
                Console.WriteLine("Can't Get Item because it's a null value boi !");
                return null;
            }
            return _itemRepository.GetById(itemId);
        }

        public bool IDExist(int itemId)
        {
            return _itemRepository.IDExist(itemId);
        }

        public bool NameExist(string itemName)
        {
            return _itemRepository.NameExist(itemName);

        }

        public bool Update(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't Update Item because it's a null value boi !");
                return false;
            }
            return _itemRepository.Update(item);
        }
    }
}
