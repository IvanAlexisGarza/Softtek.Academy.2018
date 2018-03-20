using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Entities
{
    public class TagDTO
    {
        public int TagId { get; set; }

        public string Title { get; set; }

        public IEnumerable<ItemInfoDTO> Items { get; set; }

    }
}
