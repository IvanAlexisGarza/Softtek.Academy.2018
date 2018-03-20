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
    public class ItemEF : IRepository<ItemInfoDTO>
    {
        public void Create(ItemInfoDTO item)
        {
            ItemInfo result = DataConverter.ItemInfoDTOToEntity(item);

            using (var context = new DemoContext())
            {
                context.Items.Add(result);
                context.SaveChanges();
            }
        }

        public void Delete(int itemId)
        {
            //Hard Delete, DROP value 
            //using (var context = new DemoContext())
            //{
            //    var item = context.Items.Find(itemId);
            //    context.Items.Remove(item);
            //    context.SaveChanges();
            //}

            //Soft Delete, just deactivate
            using (var context = new DemoContext())
            {
                var item = context.Items.Find(itemId);
                item.Archived = false;
                context.SaveChanges();
            }
        }

        public List<ItemInfoDTO> GetAll()
        {
            List<ItemInfoDTO> resultList = new List<ItemInfoDTO>();
            using (var context = new DemoContext())
            {
                resultList = context.Items.Select(s => new ItemInfoDTO
                {
                    Title = s.Title,
                    Archived = s.Archived,
                    StatusId = s.StatusId,
                    CreationDate = s.CreationDate,
                    Description = s.Description,
                    DueDate = s.DueDate,
                    ModDate = s.ModDate,
                    ItemId = s.ItemId,
                    Priority = s.Priority,
                }).ToList();
            }
            return resultList;
        }

        public ItemInfoDTO GetById(int itemId)
        {
            ItemInfoDTO dtoObject;

            using (var context = new DemoContext())
            {
                //QUERYABLE
                //var result = from question in context.Questions where question.QuestionId == id select question; 
                //Regresa un resultado de tipo IQueryable


                //fORMA METODO
                var result = context.Items.Where(q => q.ItemId == itemId).FirstOrDefault();


                //DESPARAMETRIZANDO result
                dtoObject = new ItemInfoDTO
                {
                    ItemId = result.ItemId,
                    Description = result.Description,
                    Tags = result.Tags.ToList().Select(opt => new TagDTO
                    {
                        TagId = opt.TagId,
                        Title = opt.Title
                    }).ToList()
                };
            }
            return dtoObject;
        }

        public void Update(ItemInfoDTO item)
        {
            //QuestionType result = DataConverter.QuestionTypeDTOToEntity(entity);

            //using (var context = new DemoContext())
            //{
            //    var found = context.QuestionTypes.Find(result.QuestionTypeId);
            //    found.Description = entity.Description;
            //    context.SaveChanges();
            //}
        }

        public void AddTags(TagDTO tagDTO, ItemInfoDTO itemInfoDTO)
        {
            ItemInfo itemInfoEntity = DataConverter.ItemInfoDTOToEntity(itemInfoDTO);
            Tag tagEntity = DataConverter.TagDTOToEntity(tagDTO);

            using (var context = new DemoContext())
            {
                //context.Items.Add(itemInfoEntity);
                //context.SaveChanges();
                //context.Tags.Add(tagEntity);
               // context.SaveChanges();
                //var found = context.Items.Find(itemInfoEntity.ItemId);
                //context.Items.Add(found);
                //context.SaveChanges();
                //if (found.Tags.Count() >= 10)
                //{
                //    Console.WriteLine("Maximun number of Tegs Reached");
                //}
                //else
                //{
                //    found.Tags.Add(tagEntity);
                //}
                //found.Tags.Add(tagEntity);/*new Tag
                //{
                //    TagId = tagEntity.TagId,
                //    Title = tagEntity.Title,
                //    Items = tagEntity.Items
                //});*/

                context.SaveChanges();
            }
        }
    }
}

