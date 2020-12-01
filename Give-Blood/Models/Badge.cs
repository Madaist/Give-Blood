using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Give_Blood.Models
{
    public class Badge
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<UserBadges> UserBadges { get; set; }
    }
}
