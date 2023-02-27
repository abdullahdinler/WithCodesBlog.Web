using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment : BaseEntity
    {
        public int BlogId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? CommentText { get; set; }
        public DateTime SendingDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }

        public Blog? Blog { get; set; }

    }
}
