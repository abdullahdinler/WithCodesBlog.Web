using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        private readonly WithCodesContext _context;
        public EfBlogDal(WithCodesContext context) : base(context)
        {
            _context = context;
        }

        public List<Blog>? GetBlogList()
        {
            var values = _context.Blogs?.Include(x => x.Category).Include(x=>x.Comments).Include(x => x.AppUser).OrderByDescending(x => x.CreateDate).ToList();
            return values;
        }

        public Blog? GetBlog(Expression<Func<Blog, bool>> filter)
        {
            var values = _context.Blogs.Include(x => x.Category).Include(x=>x.Comments).Include(x => x.AppUser).FirstOrDefault(filter);
            return values;
        }

        public List<Blog>? BlogWithCategoryList(Expression<Func<Blog, bool>> filter)
        {
            var values = _context.Blogs.Include(x => x.Category).Include(x => x.Comments).Include(x => x.AppUser).Where(filter).ToList();
            return values;
        }
    }
}
