using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Entities
{
    public class ItemInfo
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

        public virtual ICollection<Tag> Tags { get; set; }

        /*
         * Inicializa la colleccion porque si no se crea un objeto nulo 
         * public Item()
         * 
         * {
         *      Tags = new HashSet<Tag>()
         * }
         * 
         * using context
         * 
         * var item = context.items.singleordefaul)x =? x.id == itemid
         * cw result.title result.tags
         * 
         */

    }
}
