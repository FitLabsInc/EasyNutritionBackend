using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services.Communication
{
    public class ProgressResponse : BaseResponse<Progress>
    {
        public ProgressResponse(Progress resource) : base(resource)
        {
        }

        public ProgressResponse(string message) : base(message)
        {
        }
    }
}
