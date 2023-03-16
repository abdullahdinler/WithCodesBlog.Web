using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfHashtagDal:GenericRepository<Hashtag>,IHashtagDal
    {
        private readonly WithCodesContext _context;
        public EfHashtagDal(WithCodesContext context) : base(context)
        {
            _context = context;
        }

        public List<Hashtag>? GetByHashtagBlogs()
        {
            return _context.Hashtags?.Include(x => x.Blog).ToList();
        }
    }
}
