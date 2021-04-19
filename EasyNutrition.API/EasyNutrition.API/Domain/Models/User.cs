using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        public bool Active { get; set; }
        public string Linkedin { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }



        public IList<Session> Sessions { get; set; } = new List<Session>();

        public IList<SessionDetail> SessionDetails { get; set; } = new List<SessionDetail>();

        public IList<Subscription> Subscriptions { get; set; } = new List<Subscription>();

        public IList<Schedule> Schedules { get; set; } = new List<Schedule>();

        public IList<Complaint> Complaints { get; set; } = new List<Complaint>();
        public IList<Experience> Experiences { get; set; } = new List<Experience>();

    }
   
}
