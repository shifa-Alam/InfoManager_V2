using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Entities
{
    public class Country:BaseEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Members = new HashSet<Member>();
        }

        public string Name { get; set; } = null!;
        
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
