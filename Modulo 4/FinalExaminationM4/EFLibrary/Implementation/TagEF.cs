using EFLibrary.Entities;
using EFLibrary.Helper;
using EFLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Implementation
{
    public class TagEF : IRepository<TagDTO>
    {
        public TagEF()
        {
        }

        public void AddTags(TagDTO tagDTO, ItemInfoDTO itemInfoDTO)
        {
            throw new NotImplementedException();
        }

        public void Create(TagDTO item)
        {
            //future implementation to validate repeated tags  
            //if (context.Tags.Find(result.Title) != null)
            //
            Tag result = DataConverter.TagDTOToEntity(item);

            using (var context = new DemoContext())
            {
                //var found = context.Tags.Find(item.Title);
                //if (found == null)
                //{
                    context.Tags.Add(result);
                    context.SaveChanges();
                //}
                //else
                //{
                //    Console.WriteLine("That Tag name already exists, you can't create duplicate tags");
                //}
            }
        }

        public void Delete(int itemId)
        {
            using (var context = new DemoContext())
            {
                var item = context.Tags.Find(itemId);
                context.Tags.Remove(item);
                context.SaveChanges();
            }
        }

        public List<TagDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public TagDTO GetById(int itemId)
        {
            TagDTO dtoObject;

            using (var context = new DemoContext())
            {
                //QUERYABLE
                //var result = from question in context.Questions where question.QuestionId == id select question; 
                //Regresa un resultado de tipo IQueryable


                //fORMA METODO
                var result = context.Tags.Where(q => q.TagId == itemId).FirstOrDefault();


                //DESPARAMETRIZANDO result
                dtoObject = new TagDTO
                {
                    TagId = result.TagId,
                    Title = result.Title,

                };
            }
            return dtoObject;
        }

        public void Update(TagDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
