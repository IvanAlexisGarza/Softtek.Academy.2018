using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academia2018.ToDoListApp.DTO.Helpers
{
    public class Mapper
    {
        public static Item ItemDTOToEntity(ItemDTO dtoObject)
        {
            Item entity;
            if (dtoObject != null)
            {
                entity = new Item
                {
                    Id = dtoObject.Id,
                    Title = dtoObject.Title,
                    Description = dtoObject.Description,
                    CreatedDate = dtoObject.CreatedDate,
                    ModifiedDate = dtoObject.ModifiedDate,
                    DueDate = dtoObject.DueDate,
                    PriorityId = dtoObject.PriorityId,
                    StatusId = dtoObject.StatusId,
                    IsArchived = dtoObject.IsArchived
                };
            }
            else
            {
                entity = null;
            }
            return entity;
        }

        public static ItemDTO ItemEntityToDTO(Item entity)
        {
            ItemDTO dto;
            if (entity != null)
            {
                dto = new ItemDTO
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    CreatedDate = entity.CreatedDate,
                    ModifiedDate = entity.ModifiedDate,
                    DueDate = entity.DueDate,
                    PriorityId = entity.PriorityId,
                    StatusId = entity.StatusId,
                    IsArchived = entity.IsArchived
                };
            }
            else
            {
                dto = null;
            }
            return dto;
        }

        public static List<ItemDTO> ItemEntityListToDTO(List<Item> entityList)
        {
            List<ItemDTO> dtoList = new List<ItemDTO>();
            foreach (var i in entityList)
            {
                dtoList.Add(ItemEntityToDTO(i));
            }
            return dtoList;
        }

        public static Tag TagDTOToEntity(TagDTO dtoObject)
        {
            Tag entity;
            if (dtoObject != null)
            {
                entity = new Tag
                {
                    Id = dtoObject.Id,
                    Name = dtoObject.Name,
                };
            }
            else
            {
                entity = null;
            }
            return entity;
        }

        public static TagDTO TagEntitytoDTO(Tag entity)
        {
            TagDTO dtoObject;
            if (entity != null)
            {
                dtoObject = new TagDTO
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
            }
            else
            {
                dtoObject = null;
            }
            return dtoObject;
        }

        public static List<TagDTO> TagEntityListToDTO(List<Tag> entityList)
        {
            List<TagDTO> dtoList = new List<TagDTO>();
            foreach (var i in entityList)
            {
                dtoList.Add(TagEntitytoDTO(i));
            }
            return dtoList;
        }
    }
}
