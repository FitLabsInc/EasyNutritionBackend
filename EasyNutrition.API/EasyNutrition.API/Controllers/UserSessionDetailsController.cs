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
    public class UserSessionDetailsController : ControllerBase
    {
        private readonly ISessionDetailService _sessionDatailService;
        private readonly IMapper _mapper;

        public UserSessionDetailsController(ISessionDetailService sessionDetailService, IMapper mapper)
        {
            _sessionDatailService = sessionDetailService;
            _mapper = mapper;
        }

        [SwaggerOperation(
        Summary = "List all sessionDetail by User",
        Description = "List of sessionDetail by User",
        OperationId = "ListAllSessionDetailsByUser",
        Tags = new[] { "SessionDetails" })]
        [SwaggerResponse(200, "List of SessionDetail", typeof(IEnumerable<SessionDetailResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionDetailResource>), 200)]
        public async Task<IEnumerable<SessionDetailResource>> GetAllByUserAsync(int userId)
        {
            var sessionDetails = await _sessionDatailService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<SessionDetail>, IEnumerable<SessionDetailResource>>(sessionDetails);
            return resources;
        }

    }
}
