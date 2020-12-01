using Give_Blood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Give_Blood.Models
{
    public class UserBadges
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string BadgeId { get; set; }

        public virtual ApplicationUser User { get; set;}
        public virtual Badge Badge { get; set;}
    }
}
