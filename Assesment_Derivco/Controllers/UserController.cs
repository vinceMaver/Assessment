using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assesment.Core.Entities;
using Assesment.Core.Interfaces;
using Assesment.Models;
using Assessment.Core.Common.Exceptions;
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
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            { 
                var users = await userService.GetUserSignUps();

                if (users == null)
                    return new NoContentResult();

                return new OkObjectResult(_mapper.Map<IList<ApiUser>>(users));
            }
            //Should be handled by global exception handler
            catch (ValidateException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
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
            try
            {
                var user = _mapper.Map<User>(userCreateModel);
                await userService.AddUserSignUp(user);

                return CreatedAtRoute(
                        routeName: "Get",
                        routeValues: new { id = user.Id },
                        value: new ApiUser { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email });
            }
            //Should be handled by global exception handler
            catch (ValidateException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
