using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Hashtag : BaseEntity
    {
        public string? Name { get; set; }
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
