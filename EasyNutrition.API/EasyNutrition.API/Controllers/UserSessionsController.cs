using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EasyNutrition.API.Domain.Services;
using Swashbuckle.AspNetCore.Annotations;
using EasyNutrition.API.Extensions;
using EasyNutrition.API.Resources;
using EasyNutrition.API.Domain.Models;
using Microsoft.AspNetCore.Cors;

namespace EasyNutrition.API.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [EnableCors("AnotherPolicy")]
    [Route("api/[controller]")]
    public class UserSessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;


        public UserSessionsController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }


        [SwaggerOperation(
         Summary = "List session by user",
         Description = "List of session by user",
         OperationId = "ListAllSessionsByUser",
         Tags = new[] { "Sessions" })]
        [SwaggerResponse(200, "List of Session", typeof(IEnumerable<SessionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionResource>), 200)]
        public async Task<IEnumerable<SessionResource>> GetAllByUserAsync(int userId)
        {
            var sessions = await _sessionService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionResource>>(sessions);
            return resources;
        }

    }


}
