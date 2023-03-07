using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericRepository<Blog>
    {
        List<Blog>? GetBlogList();
        Blog? GetBlog(Expression<Func<Blog, bool>> filter);
        List<Blog>? BlogWithCategoryList(Expression<Func<Blog, bool>> filter);
        List<Hashtag>? GetBlogWithHashtagList(Expression<Func<Hashtag, bool>> filter);


    }
}
