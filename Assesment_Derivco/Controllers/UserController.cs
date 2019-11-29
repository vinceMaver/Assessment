using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment.Core.Entities;
using Assesment.Core.Interfaces;
using Assesment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_Derivco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this._mapper = mapper;

        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        
        public async Task<IActionResult> Post([FromBody] ApiCreateUser userCreateModel)
        {
                var user = _mapper.Map<User>(userCreateModel);
                await userService.AddUserSignUp(user);

                return CreatedAtRoute(
                      routeName: "Get",
                      routeValues: new { id = user.Id },
                      value: new { FirstName = user.FirstName });
        }
    }
}
