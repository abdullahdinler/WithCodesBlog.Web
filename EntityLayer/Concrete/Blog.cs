using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog:BaseEntity
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string? Title { get; set; }
        public string? ContentText { get; set; }
        public string? ThumbnailImageUri { get; set; }
        public string? ImageUri { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }


        public Category? Category { get; set; }
        public AppUser? AppUser { get; set; }
        public virtual  ICollection<Comment>? Comments { get; set; }


    }
}
