using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SocialMedia : BaseEntity
    {
        public string? Icon { get; set; }
        public string? SocialMediaUri { get; set; }
    }
}
