using FormulatyLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulatyLib.Buisness
{
    public class AddressRepository : IGenericRepository<Address>
    {
        public AddressRepository()
        {

        }

        private readonly List<Address> AddressList;

        public AddressRepository(List<Address> addressList)
        {
            AddressList = addressList;
        }

        public void Create(Address Item)
        {
            AddressList.Add(Item);
        }

        public bool Delete(int Id)
        {
            return AddressList.Remove(SearchId(Id));
        }

        public List<Address> Search(string Filter = "")
        {
            if (Filter.Equals(""))
            {
                return AddressList;
            }
            return AddressList.Where(e => e.FullAddress.Contains(Filter)).ToList();
        }

        public Address SearchId(int Id)
        {
            return AddressList.Where(e => e.Id == Id).FirstOrDefault();
        }

        public List<Address> Update(Address Item)
        {
            Delete(Item.Id);

            Create(Item);

            return AddressList;
        }
    }

}
