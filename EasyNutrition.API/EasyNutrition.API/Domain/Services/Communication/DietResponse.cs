using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services.Communication
{
    public class DietResponse : BaseResponse<Diet>
    {
        public DietResponse(Diet resource) : base(resource)
        {
        }

        public DietResponse(string message) : base(message)
        {
        }
    }
}
