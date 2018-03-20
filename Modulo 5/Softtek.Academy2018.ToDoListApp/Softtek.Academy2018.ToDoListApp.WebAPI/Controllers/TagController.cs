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
    [RoutePrefix("api/Tag")]
    public class TagController : ApiController
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] TagDTO tagDTO)
        {
            if (tagDTO == null) return BadRequest("Request is null");

            Tag tag = new Tag
            {
                Name = tagDTO.Name,
                CreatedDate = tagDTO.CreatedDate,
                ModifiedDate =tagDTO.ModifiedDate,
            };


            int id = _tagService.Create(tag);

            if (id <= 0) return BadRequest("Unable to create Task boi !");

            var payload = new { TagId = id };

            return Ok(payload);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            Tag tag = _tagService.GetById(id);

            if (tag == null) return NotFound();

            TagDTO tagDTO = new TagDTO
            {
                Name = tag.Name,
                CreatedDate = tag.CreatedDate,
                ModifiedDate = tag.ModifiedDate,
            };

            return Ok(tagDTO);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var result = _tagService.Delete(id);

            if (!result) return BadRequest("Unable to delete user");

            return Ok();
        }

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult UpdateTag([FromUri] int id, [FromBody] TagDTO tagDTO)
        {
            if (tagDTO == null) return BadRequest("Tag is null");
            Tag tag = new Tag
            {
                Name = tagDTO.Name,
                CreatedDate = tagDTO.CreatedDate,
                ModifiedDate = tagDTO.ModifiedDate,
            };

            bool result = _tagService.Update(tag);

            if (!result) return BadRequest("Unable to update user");
            return Ok();
        }

    }
}