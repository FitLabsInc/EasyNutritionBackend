using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Resources
{
    public class SaveProgressResource
    {
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
       
        
        public int SessionId { get; set; }

    }
}
