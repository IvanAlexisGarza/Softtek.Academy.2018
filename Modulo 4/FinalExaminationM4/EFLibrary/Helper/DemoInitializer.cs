using EFLibrary.Entities;
using EFLibrary.Implementation;
using EFLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Helper
{
    public class DemoInitializer
    {
        public void DBFiller()
        {
            using (var context = new DemoContext())
            {

                IRepository<ItemInfoDTO> itemRepository = new ItemEF();
                IRepository<TagDTO> tagRepository = new TagEF();

                tagRepository.Create(new TagDTO { Title = "Testing Parameter 0",});
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 1", });
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 2", });
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 3", });
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 4", });
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 5", });
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 6", });
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 7", });
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 8", });
                tagRepository.Create(new TagDTO { Title = "Testing Parameter 9", });

                context.SaveChanges();

                itemRepository.Create(new ItemInfoDTO { Title = "Test0", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27)});//Just figured out how to add to the new one 
                itemRepository.Create(new ItemInfoDTO { Title = "Test1", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });
                itemRepository.Create(new ItemInfoDTO { Title = "Test1", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });
                itemRepository.Create(new ItemInfoDTO { Title = "Test2", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });
                itemRepository.Create(new ItemInfoDTO { Title = "Test3", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });
                itemRepository.Create(new ItemInfoDTO { Title = "Test4", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });
                itemRepository.Create(new ItemInfoDTO { Title = "Test5", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });
                itemRepository.Create(new ItemInfoDTO { Title = "Test6", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });
                itemRepository.Create(new ItemInfoDTO { Title = "Test7", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });
                itemRepository.Create(new ItemInfoDTO { Title = "Test8", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) });

                context.SaveChanges();

                //Create Title 
                //Console.WriteLine("Enter Title:");
                //string itemTitle = Console.ReadLine();
            }
        }
    }
}
