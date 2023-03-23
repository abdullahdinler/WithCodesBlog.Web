using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentAnswerManager : ICommentAnswerService
    {
        private readonly ICommentAnswerDal _answerDal;
        public CommentAnswerManager(ICommentAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }

        public void Add(CommentAnswer entity)
        {
            _answerDal.Add(entity);
        }

        public void Delete(CommentAnswer entity)
        {
            _answerDal.Delete(entity);
        }

        public CommentAnswer? Get(int id)
        {
            return _answerDal.GetById(x => x.Id == id);
        }

        public List<CommentAnswer>? GetAllList()
        {
            return _answerDal.GetAll();
        }

        public void Update(CommentAnswer entity)
        {
            _answerDal.Update(entity);
        }
    }
}
