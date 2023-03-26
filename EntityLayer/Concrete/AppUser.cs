using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string? NameSurname { get; set; }
        public string? ImageUri { get; set; }

        public virtual ICollection<Blog>? Blogs { get; set; }
        public virtual ICollection<CommentAnswer> CommentAnswers { get; set; }

    }
}
