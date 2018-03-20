using Softtek.Academia2018.ToDoListApp.DTO;
using Softtek.Academia2018.ToDoListApp.DTO.Helpers;
using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Business.Implementations;
using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using Softtek.Academy2018.ToDoListApp.Data.Implementations;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Softtek.Academy2018.ToDoListApp.WebAPI.Controllers
{
    [RoutePrefix("Items")]
    public class ItemController : ApiController
    {
        private readonly IItemBL itemBL;

        public ItemController()
        {
            IItemDL itemDL = new ItemDL();

            this.itemBL = new ItemBL(itemDL);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ItemDTO itemDTO)
        {

            if (itemDTO == null) BadRequest("Request is null");

            Item item = Mapper.ItemDTOToEntity(itemDTO);

            int id = itemBL.CreateItem(item);

            if (id <= 0) return BadRequest("Unable to create item");

            var payload = new { ItemId = id };

            return Ok(payload);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] ItemDTO itemDTO)
        {
            if (itemDTO == null) BadRequest("Request is null");

            Item item = Mapper.ItemDTOToEntity(itemDTO);

            bool isUpdated = itemBL.UpdateItem(item);

            if (isUpdated == false) return BadRequest("Unable to update item");

            return Ok(isUpdated);
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllItems()
        {
            List<Item> items = itemBL.GetAllItems();

            if (items == null) return NotFound();

            List<ItemDTO> itemDTOs = Mapper.ItemEntityListToDTO(items);

            return Ok(itemDTOs);
        }

        ///Tags?begin_date=01-01-2018&end_date=03-03-2018
        [Route("begin_date/{beginDate}/end_date/{endDate}")]
        [HttpGet]
        public IHttpActionResult SearchItemsbyRangeDate([FromBody] DateTime beginDate, DateTime endDate)
        {
            List<Item> items = itemBL.SearchItemsbyRangeDate(beginDate,endDate);

            if (items == null) return NotFound();

            List<ItemDTO> itemDTOs = Mapper.ItemEntityListToDTO(items);

            return Ok(itemDTOs);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]  int id)
        {
            Item item = itemBL.GetItemById(id);

            if (item == null) return NotFound();

            ItemDTO itemDTO = Mapper.ItemEntityToDTO(item);

            return Ok(itemDTO);
        }

        [Route("Status/{id}")]
        [HttpGet]
        public IHttpActionResult SearchItemsbyStatusId([FromUri] int id)
        {
            List<Item> items = itemBL.SearchItemsbyStatusId(id);

            if (items == null) return NotFound();

            List<ItemDTO> itemDTOs = Mapper.ItemEntityListToDTO(items);

            return Ok(itemDTOs);
        }

        [Route("Title/{title}")]
        [HttpGet]
        public IHttpActionResult SearchItemsbyTitle([FromUri] string title)
        {
            List<Item> items = itemBL.SearchItemsbyTitle(title);

            if (items == null) return NotFound();

            List<ItemDTO> itemDTOs = Mapper.ItemEntityListToDTO(items);

            return Ok(itemDTOs);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult ArchiveItem([FromUri] int id)
        {
            Item item = itemBL.GetItemById(id);

            if (item == null) return NotFound();

            bool delete = itemBL.ArchiveItem(id);

            return Ok(delete);
        }

        [Route("{itemId}/Tag/{tagId}")]
        [HttpPost]
        public IHttpActionResult AddTagToItem([FromUri] int itemId, int tagId)
        {
            bool added = itemBL.AddTagToItem(itemId, tagId);

            return Ok(added);
        }

        [Route("Tag/{tagId}")]
        [HttpGet]
        public IHttpActionResult GetItemsbyTagId([FromUri] int tagId)
        {
            List<Item> items = itemBL.SearchItemsbyTagId(tagId);

            if (items == null) return NotFound();

            List<ItemDTO> itemDTOs = Mapper.ItemEntityListToDTO(items);

            return Ok(itemDTOs);
        }
    }
}
