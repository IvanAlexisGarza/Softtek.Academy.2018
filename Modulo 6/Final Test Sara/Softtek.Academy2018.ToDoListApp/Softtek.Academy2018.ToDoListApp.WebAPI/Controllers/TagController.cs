using Softtek.Academia2018.ToDoListApp.DTO;
using Softtek.Academia2018.ToDoListApp.DTO.Helpers;
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

   [RoutePrefix("Tags")]
   public class TagController : ApiController
   {
        private readonly TagBL tagBL;

        public TagController()
        {
            ITagDL tagDL = new TagDL();
            this.tagBL = new TagBL(tagDL);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]  int id)
        {
            Tag tag = tagBL.GetTagById(id);

            if (tag == null) return NotFound();

            TagDTO tagDTO = Mapper.TagEntitytoDTO(tag);

            return Ok(tagDTO);
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllTags()
        {
            List<Tag> tags = tagBL.GetAllTags();

            if (tags == null) return NotFound();

            List<TagDTO> tagDTOs = Mapper.TagEntityListToDTO(tags);

            return Ok(tagDTOs);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] TagDTO tagDTO)
        {
            if (tagDTO == null) BadRequest();

            Tag tag = Mapper.TagDTOToEntity(tagDTO);

            int id = tagBL.CreateTag(tag);

            if (id <= 0) return BadRequest("Unable to Create Tag");

            return Ok(tag);
        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri]  int id)
        {
            Tag tag = tagBL.GetTagById(id);

            if (tag == null) return NotFound();

            bool delete = tagBL.ArchiveTag(id);

            return Ok(delete);
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Update([FromBody]  TagDTO tagDTO)
        {
            if (tagDTO == null) BadRequest("Request is null");

            Tag tag = Mapper.TagDTOToEntity(tagDTO);

            bool isUpdated = tagBL.UpdateTag(tag);

            if (isUpdated == false) return BadRequest("Unable to update tag");

            return Ok(isUpdated);
        }
    }
}
