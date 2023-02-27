using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Notification : BaseEntity
    {
        public string? Title { get; set; }
        public string? ContentText { get; set; }
        public DateTime SendingDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
    }
}
