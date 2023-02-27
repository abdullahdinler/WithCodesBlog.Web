using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact:BaseEntity
    {
        public string? FullName { get; set; }
        public string? Email { get; set; } 
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BlogEmail { get; set; } 
        public string? BlogAddress { get; set; }
        public DateTime SendingDate { get; set; } = DateTime.Now;
        public bool Status { get; set;}
    }
}
