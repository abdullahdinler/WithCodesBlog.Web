using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog : BaseEntity
    {
        public int CategoryId { get; set; }
        public int AppUserId { get; set; }
        public string? Title { get; set; }
        public string? ContentText { get; set; }
        public string? ThumbnailImageUri { get; set; }
        public string? ImageUri { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        [Column("Slug")]
        private string? _slug;

        public string? Slug
        {
            get
            {
                return _slug ?? Title.ToLower().Replace(" ", "-").Replace("ı", "i").Replace("ğ", "g").Replace("ç", "c")
                    .Replace("ö", "o").Replace("ü", "u").Replace("ş", "s").Replace("$", "s");
            }
            set
            {
                _slug = value;
            }
        }



        public Category? Category { get; set; }
        public AppUser? AppUser { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }


    }
}
