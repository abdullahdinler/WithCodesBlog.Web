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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal:GenericRepository<Comment>,ICommentDal
    {
        private readonly WithCodesContext _context;
        public EfCommentDal(WithCodesContext context) : base(context)
        {
            _context = context;
        }

        public List<Comment>? GetCoomentWithBlogAuthor(Expression<Func<Comment, bool>> filter)
        {
            return _context.Comments?.Include(x=>x.Blog).Include(x=>x.CommentAnswers).Where(filter).ToList();
        }
    }
}
