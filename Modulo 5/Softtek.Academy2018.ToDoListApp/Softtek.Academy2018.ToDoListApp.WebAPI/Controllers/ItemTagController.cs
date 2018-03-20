using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Softtek.Academy2018.ToDoListApp.WebAPI.Controllers
{
    [RoutePrefix("api/ItemTag")]
    public class ItemTagController : ApiController
    {
        private readonly IItemTagService _itemTagService;
        private readonly ITagService _tagService;
        private readonly IItemService _itemService;

        public ItemTagController(IItemTagService itemTagService, 
                                 ITagService tagService, IItemService itemService)
        {
            _itemTagService = itemTagService;
            _tagService = tagService;
            _itemService = itemService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] int itemId, int tagId)
        {
            //This one is a bit ugly becuse VS2017 was being moody and i didin't have time to deal with her 

            if(!_tagService.IDExist(tagId)) return BadRequest("the tag id dosen't even exist !");

            if (!_itemService.IDExist(itemId)) return BadRequest("the task id dosen't even exist !");

            if (! _itemTagService.AddTagToItem(itemId,  tagId)) return BadRequest("Unable to create Inyection boi !");

            var payload = new { result = true };
            return Ok(payload);
        }
    }
}