using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services.Communication
{
    public class SessionDetailResponse : BaseResponse<SessionDetail>
    {
        public SessionDetailResponse(SessionDetail resource) : base(resource)
        {
        }

        public SessionDetailResponse(string message) : base(message)
        {
        }
    }
}
