using EFLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T item);

        void Update(T item);

        void Delete(int itemId);

        List<T> GetAll();

        T GetById(int itemId);

        void AddTags(TagDTO tagDTO, ItemInfoDTO itemInfoDTO);
    }
}
