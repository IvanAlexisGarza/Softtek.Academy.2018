using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Entities
{
    public class ItemInfoDTO
    {
        public int ItemId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Archived { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModDate { get; set; }

        public DateTime DueDate { get; set; }

        public int Priority { get; set; }

        public int StatusId { get; set; }

        public ICollection<TagDTO> Tags { get; set; }
    }
}
