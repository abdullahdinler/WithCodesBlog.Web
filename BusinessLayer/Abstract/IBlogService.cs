using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog>? GetBlogWithCategoryList();
        List<Blog>? Search(string search);
        Blog? GetBlogById(int id);
        Blog? GetBlogBySlug(string slug);
        List<Blog>? BlogListByCategory(string categoryName);
        List<Blog>? BlogListByAuthor(string authorName);
        List<Hashtag>? BlogListByHashtag(string hashtagName);
    }
}
