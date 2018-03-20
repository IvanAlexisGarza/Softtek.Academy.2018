using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlobal { get; set; }

        public Tag(int id, string name, bool isGlobal)
        {
            Id = id;
            Name = name;
            IsGlobal = isGlobal;
        }

        public Tag(string name, bool isGlobal)
        {
            Name = name;
            IsGlobal = isGlobal;
        }
    }
}
