using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CommentAnswer : BaseEntity
    {
       
        public string? Answer { get; set; }
        public DateTime SendingDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }

        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public int CommentId { get; set; }
        public Comment? Comment { get; set; }
    }
}
