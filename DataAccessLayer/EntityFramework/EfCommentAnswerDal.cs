using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentAnswerDal : GenericRepository<CommentAnswer>, ICommentAnswerDal
    {
        private readonly WithCodesContext _context;
        public EfCommentAnswerDal(WithCodesContext context) : base(context)
        {
            _context = context;
        }

        public CommentAnswer? GetCommentAnswerWithComment(Expression<Func<CommentAnswer, bool>> filter)
        {
            if (_context.CommentAnswers is null) return default(CommentAnswer);
            return _context.CommentAnswers.Include(x => x.Comment).Where(filter).SingleOrDefault();
        }
    }
}
