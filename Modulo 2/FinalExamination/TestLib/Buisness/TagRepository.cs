using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLib.Entity;

namespace TestLib.Buisness
{
    public class TagRepository
    {

        private readonly List<Tag> TagList;

       public void CreateTag(Tag item)
        {
            for(int i=0; i<= TagList.Count(); i++)
            {
                if(item.Name == TagList[i].Name)
                {
                    Console.WriteLine("Tag Already exists");
                    break;
                }
            }
            TagList.Add(item);
        }

        public void RemoveTag(Tag item)
        {
            TagList.Remove(item);
        }


    }
}
