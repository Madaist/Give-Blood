using Give_Blood.Models;
using System.Collections.Generic;

namespace Give_Blood.Models
{
    public class League
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
