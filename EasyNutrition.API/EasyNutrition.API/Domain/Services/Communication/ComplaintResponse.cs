using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Services.Communication
{
    public class ComplaintResponse : BaseResponse<Complaint>
    {
        public ComplaintResponse(Complaint resource) : base(resource)
        {

        }

        public ComplaintResponse(string message) : base(message)
        {
        }

    }


}
