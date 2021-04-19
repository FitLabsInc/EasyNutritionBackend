using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Resources
{
    public class ComplaintResource
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public UserResource User { get; set; }


    }


}