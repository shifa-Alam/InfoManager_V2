using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.Core.Entities
{
    public class City : BaseEntity
    {

        public City()
        {
            Members = new HashSet<Member>();
        }


        public string Name { get; set; } = null!;
        public long CountryId { get; set; }
       

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Member> Members { get; set; }
    }
}
