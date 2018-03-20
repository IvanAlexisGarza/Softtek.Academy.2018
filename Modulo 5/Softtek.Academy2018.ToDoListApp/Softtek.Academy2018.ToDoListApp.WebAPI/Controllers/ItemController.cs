using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Domain.Model;
using Softtek.Academy2018.ToDoListApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Softtek.Academy2018.ToDoListApp.WebAPI.Controllers
{
    [RoutePrefix("api/Item")]
    public class ItemController : ApiController
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ItemDTO itemDTO)
        {
            if (itemDTO == null) return BadRequest("Request is null");

            Item item = new Item
            {
                Title = itemDTO.Title,
                Description = itemDTO.Description,
                DueDate = itemDTO.DueDate,
                StatusId = itemDTO.StatusId,
                PriorityId =itemDTO.PriorityId,
            };


            int id = _itemService.Create(item);

            if (id <= 0) return BadRequest("Unable to create Task boi !");

            var payload = new { ItemId = id };

            return Ok(payload);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById([FromUri] int id)
        {
            Item item = _itemService.GetById(id);

            if (item == null) return NotFound();

            ItemDTO itemDTO = new ItemDTO
            {
                Title = item.Title,
                Description = item.Description,
                DueDate = item.DueDate,
                StatusId = item.StatusId,
                PriorityId = item.PriorityId,
            };

            return Ok(itemDTO);
        }

        [Route("/Status/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByStatus([FromUri] int priorityId)
        {
            ICollection<Item> items = _itemService.GetByPriority(priorityId);

            if (items == null)
                return BadRequest("Unable to get projects");

            ICollection<ItemDTO> itemList = items.Select(x => new ItemDTO
            {
                Description = x.Description,
                StatusId = x.StatusId,
                Title = x.Title,
                DueDate = x.DueDate,
                PriorityId = x.PriorityId
            }).ToList();

            return Ok(itemList);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var result = _itemService.Delete(id);

            if (!result) return BadRequest("Unable to delete user");

            return Ok();
        }

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult UpdateItem([FromUri] int id, [FromBody] ItemDTO itemDTO)
        {
            if (itemDTO == null) return BadRequest("Item is null");
            Item item = new Item
            {
                Id = id,
                Title = itemDTO.Title,
                Description = itemDTO.Description,
                DueDate = itemDTO.DueDate,
                StatusId = itemDTO.StatusId,
                PriorityId = itemDTO.PriorityId,
            };

            bool result = _itemService.Update(item);

            if (!result) return BadRequest("Unable to update user");
            return Ok();
        }

    }
}