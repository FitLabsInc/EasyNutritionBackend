using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services.Communication
{
    public class ExperienceResponse : BaseResponse<Experience>
    {
        public ExperienceResponse(Experience resource) : base(resource)
        {

        }

        public ExperienceResponse(string message) : base(message)
        {
        }

    }
    
}

