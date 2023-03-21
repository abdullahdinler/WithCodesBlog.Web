using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EntityLayer.Concrete
{
    public class About : BaseEntity
    {
       
        public string? ContentText { get; set; }
        public string? ImageUri { get; set; }
    }

   
}
