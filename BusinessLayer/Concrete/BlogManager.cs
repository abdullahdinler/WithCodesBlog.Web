using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog>? GetAllList()
        {
            return _blogDal.GetAll();
        }

        public Blog? Get(int id)
        {
            return _blogDal.GetById(x => x.Id == id);
        }

        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog>? GetBlogWithCategoryList()
        {
            return _blogDal.GetBlogList();
        }

        public Blog? GetBlogById(int id)
        {
            return _blogDal.GetBlog(x => x.Id == id);
        }

        public Blog? GetBlogBySlug(string slug)
        {
            return _blogDal.GetBlog(x => x.Slug == slug);
        }

        public List<Blog>? BlogListByCategory(string categoryName)
        {
            return _blogDal.BlogWithCategoryList(x => x.Category != null && x.Category.Name == categoryName);
        }
    }
}
