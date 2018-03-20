using Softtek.Academy2018.Demo.Business.Contracts;
using Softtek.Academy2018.Demo.Business.Implementation;
using Softtek.Academy2018.Demo.Data.Contracts;
using Softtek.Academy2018.Demo.Data.Implementation;
using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Softtek.Academy2018.Demo.WebAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] UserDTO userDTO)
        {
            if (userDTO == null) return BadRequest("Request is null");

            User user = new User
            {
                IS = userDTO.IS,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                DateOfBirth = userDTO.DateOfBirth,
                Salary = userDTO.Salary,
                CreatedDate = userDTO.CreatedDate,
                ModifiedDate = userDTO.ModifiedDate
            };

            int id = _userService.Add(user);

            if (id <= 0) return BadRequest("Unable to create user");

            var payload = new { UserId = id };

            return Ok(payload);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            User user = _userService.Get(id);

            if (user == null) return NotFound();

            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                IS = user.IS,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Salary = user.Salary,
                CreatedDate = user.CreatedDate,
                ModifiedDate = user.ModifiedDate
            };

            return Ok(userDTO);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            var result = _userService.Delete(id);

            if (!result) return BadRequest("Unable to delete user");

            return Ok();
        }

        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult UpdateUser([FromUri] int id,[FromBody] UserDTO userDTO)
        {
            if (userDTO == null) return BadRequest("User is null");
            User user = new User
            {
                Id = id,
                IS = userDTO.IS,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Salary = userDTO.Salary,
                DateOfBirth = userDTO.DateOfBirth
            };

            bool result =_userService.Update(user);

            if (!result) return BadRequest("Unable to update user");
            return Ok();
        }
    }
}
