using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int MaxSessions { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

