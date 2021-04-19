using EasyNutrition.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Resources
{
    public class SaveUserResource
    {

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(10)]
        public string Birthday { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public bool Active { get; set; }

        [Required]
        [MaxLength(100)]
        public string Linkedin { get; set; }

        public int RoleId { get; set; }



    }
}
