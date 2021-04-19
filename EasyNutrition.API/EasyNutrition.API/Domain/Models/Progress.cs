using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
