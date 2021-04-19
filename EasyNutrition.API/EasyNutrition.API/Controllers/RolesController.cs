using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Extensions;
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
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
    
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "List all roles",
            Description = "List of Roles",
            OperationId = "ListAllRoles",
            Tags = new[] {"Roles"})]
        [SwaggerResponse(200, "List of Roles",typeof(IEnumerable<RoleResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleResource>),200)]
        public async Task<IEnumerable<RoleResource>> GetAllAsync()
        {
            var roles = await _roleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(roles);
            return resources;
        }

        [SwaggerOperation(
            Summary = "Add role",
            Description = "Add new role",
            OperationId = "AddRole",
            Tags = new[] { "Roles" })]
        [SwaggerResponse(200, "Add Roles", typeof(IEnumerable<RoleResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<RoleResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var role = _mapper.Map<SaveRoleResource, Role>(resource);
            var result = await _roleService.SaveAsync(role);

            if (!result.Success)
                return BadRequest(result.Message);

            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }


        [SwaggerOperation(
            Summary = "Update role",
            Description = "Update a role",
            OperationId = "UpdateRole",
            Tags = new[] { "Roles" })]
        [SwaggerResponse(200, "Update Roles", typeof(IEnumerable<RoleResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<RoleResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoleResource resource)
        {
            var role = _mapper.Map<SaveRoleResource, Role>(resource);
            var result = await _roleService.UpdateAsync(id, role);

            if (!result.Success)
                return BadRequest(result.Message);
            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }


        [SwaggerOperation(
        Summary = "Delete role",
        Description = "Delete a role",
        OperationId = "DeleteRole",
        Tags = new[] { "Roles" })]
        [SwaggerResponse(200, "Delete Roles", typeof(IEnumerable<RoleResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<RoleResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);

        }
    }
}
