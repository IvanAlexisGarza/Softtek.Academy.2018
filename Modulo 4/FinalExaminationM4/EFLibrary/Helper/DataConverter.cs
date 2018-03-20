using EFLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Helper
{
    public class DataConverter
    {
        #region ItemInfo Converters
        public static ItemInfo ItemInfoDTOToEntity(ItemInfoDTO itemInfoDTO)
        {
            ItemInfo result = new ItemInfo
            {
                ItemId = itemInfoDTO.ItemId,
                Title = itemInfoDTO.Title,
                Description = itemInfoDTO.Description,
                CreationDate = itemInfoDTO.CreationDate,
                ModDate = itemInfoDTO.ModDate,
                Priority = itemInfoDTO.Priority,
                StatusId = itemInfoDTO.StatusId,
                Archived = itemInfoDTO.Archived,
                DueDate = itemInfoDTO.DueDate
            };
            return result;
        }

        public static ItemInfoDTO ItemInfoEntityToDTO(ItemInfo itemInfoEntity)
        {
            ItemInfoDTO result = new ItemInfoDTO
            {
                ItemId = itemInfoEntity.ItemId,
                Title = itemInfoEntity.Title,
                Description = itemInfoEntity.Description,
                CreationDate = itemInfoEntity.CreationDate,
                ModDate = itemInfoEntity.ModDate,
                Priority = itemInfoEntity.Priority,
                StatusId = itemInfoEntity.StatusId,
                Archived = itemInfoEntity.Archived,
                DueDate = itemInfoEntity.DueDate
            };
            return result;
        }
        #endregion

        #region Tag Converters
        public static Tag TagDTOToEntity(TagDTO tagDTO)
        {
            Tag result = new Tag
            {
                Title = tagDTO.Title
            };
            return result;
        }

        public static TagDTO TagEntityToDTO(Tag tagEntity)
        {
            TagDTO result = new TagDTO
            {
                Title = tagEntity.Title
            };
            return result;
        }
        #endregion
    }
}
