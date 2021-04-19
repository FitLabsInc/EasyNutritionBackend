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
    [Route("/api/users/{userId}/subscription")]
    public class UserSubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;

        public UserSubscriptionsController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List Subscription by User",
          Description = "List of Subscription by User",
          OperationId = "ListSubscriptionByUser",
          Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "List of Users", typeof(IEnumerable<SubscriptionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IEnumerable<SubscriptionResource>> GetAllBySubscriptionAsync(int userId)
        {
            var subscriptions = await _subscriptionService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscriptions);
            return resources;
        }




    }
}
