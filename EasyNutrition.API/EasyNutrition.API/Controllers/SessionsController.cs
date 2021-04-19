using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EasyNutrition.API.Domain.Services;
using Swashbuckle.AspNetCore.Annotations;
using EasyNutrition.API.Resources;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Extensions;
using Microsoft.AspNetCore.Cors;

namespace EasyNutrition.API.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [EnableCors("AnotherPolicy")]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {


        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public SessionsController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
         Summary = "List all session",
         Description = "List of session",
         OperationId = "ListAllSessions",
         Tags = new[] { "Sessions" })]
        [SwaggerResponse(200, "List of Session", typeof(IEnumerable<SessionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionResource>), 200)]
        public async Task<IEnumerable<SessionResource>> GetAllAsync()
        {
            var sessions = await _sessionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionResource>>(sessions);
            return resources;
        }


        [SwaggerOperation(
              Summary = "Add Sessions",
              Description = "Add new Session",
              OperationId = "AaddSession",
              Tags = new[] { "Sessions" })]
        [SwaggerResponse(200, "Add Session", typeof(IEnumerable<SessionResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<SessionResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSessionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var sessions = _mapper.Map<SaveSessionResource, Session>(resource);
            var result = await _sessionService.SaveAsync(sessions);

            if (!result.Success)
                return BadRequest(result.Message);

            var sessionResource = _mapper.Map<Session, SessionResource>(result.Resource);
            return Ok(sessionResource);
        }



        [SwaggerOperation(
            Summary = "Update session by User",
            Description = "Update a session by User",
            OperationId = "UpdateSessionUser",
            Tags = new[] { "Sessions" })]
        [SwaggerResponse(200, "Update Sessions by User", typeof(IEnumerable<SessionResource>))]
        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<SessionResource>), 200)]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveSessionResource resource)
        {
            var session = _mapper.Map<SaveSessionResource, Session>(resource);
            var result = await _sessionService.UpdateAsync(userId, session);

            if (!result.Success)
                return BadRequest(result.Message);
            var sessionResource = _mapper.Map<Session, SessionResource>(result.Resource);
            return Ok(sessionResource);
        }

        [SwaggerOperation(
         Summary = "Delete Session",
         Description = "Delete a Session",
         OperationId = "Deletesession",
         Tags = new[] { "Sessions" })]
        [SwaggerResponse(200, "Delete Sessions", typeof(IEnumerable<SessionResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<SessionResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _sessionService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var sessionResource = _mapper.Map<Session, SessionResource>(result.Resource);
            return Ok(sessionResource);
        }

    }
}
