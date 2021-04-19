using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services.Communication
{
    public class SubscriptionResponse : BaseResponse<Subscription>
    {
        public SubscriptionResponse(Subscription resource) : base(resource)
        {
        }

        public SubscriptionResponse(string message) : base(message)
        {
        }

    }
}

