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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment>? GetAllList()
        {
            return _commentDal.GetAll();
        }

        public Comment? Get(int id)
        {
            return _commentDal.GetById(x => x.Id == id);
        }

        public void Add(Comment entity)
        {
            _commentDal.Add(entity);
        }

        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }

        public void Delete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public List<Comment>? GetAllList(string slug)
        {
            return _commentDal.GetAll(x => x.Blog.Slug == slug).Where(x => x.Status == true).ToList();
        }
    }
}
