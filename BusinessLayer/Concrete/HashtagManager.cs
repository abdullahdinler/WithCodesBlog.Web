using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using X.PagedList;

namespace BusinessLayer.Concrete
{
    public class HashtagManager: IHastagService
    {
        private readonly IHashtagDal _hashtagDal;

        public HashtagManager(IHashtagDal hashtagDal)
        {
            _hashtagDal = hashtagDal;
        }

        public List<Hashtag>? GetAllList()
        {
            return _hashtagDal.GetAll();
        }

        public Hashtag? Get(int id)
        {
            return _hashtagDal.GetById(x => x.Id == id);
        }

        public void Add(Hashtag entity)
        {
            _hashtagDal.Add(entity);
        }

        public void Update(Hashtag entity)
        {
            _hashtagDal.Update(entity);
        }

        public void Delete(Hashtag entity)
        {
            _hashtagDal.Delete(entity);
        }

        public List<Hashtag>? GetHashtagWithBlog()
        {
            return _hashtagDal.GetByHashtagBlogs();
        }
    }
}
