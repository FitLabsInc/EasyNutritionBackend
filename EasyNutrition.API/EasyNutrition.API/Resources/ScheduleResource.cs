using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Resources
{
    public class ScheduleResource
    {


        public int Id { get; set; }

        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public bool State { get; set; }

     

        public UserResource User { get; set; }

    }
}
