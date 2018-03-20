using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulatyLib.Entity
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string FullAddress { get { return Id + " " + Country + " " + City + " " + Street + " " + Number + " " + PostalCode; } }

        public Address()
        {
        }
    }
}
