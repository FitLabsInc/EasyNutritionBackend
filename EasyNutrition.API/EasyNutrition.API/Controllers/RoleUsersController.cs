using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Resources;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [EnableCors("AnotherPolicy")]
    [Route("/api/roles/{roleId}/users")]
    public class RoleUsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RoleUsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List users by Role",
          Description = "List of Users by Role",
          OperationId = "ListUsersByRole",
          Tags = new[] { "Users" })]
        [SwaggerResponse(200, "List of Roles", typeof(IEnumerable<UserResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        public async Task<IEnumerable<UserResource>> GetAllByRoleAsync(int roleId)
        {
            var users = await _userService.ListByRoleIdAsync(roleId);
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }


    }
}
