using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EasyNutrition.API.Resources
{
    public class SaveSubscriptionResource
    {
      
        public bool Active { get; set; }
        public int MaxSessions { get; set; }
        public int Price { get; set; }

        public int UserId { get; set; }


    }
}
