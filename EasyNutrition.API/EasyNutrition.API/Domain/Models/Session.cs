using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        public string Link { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IList<SessionDetail> SessionDetails { get; set; } = new List<SessionDetail>();

        public IList<Diet> Diets { get; set; } = new List<Diet>();
        public IList<Progress> Progresses { get; set; } = new List<Progress>();
    }
}

