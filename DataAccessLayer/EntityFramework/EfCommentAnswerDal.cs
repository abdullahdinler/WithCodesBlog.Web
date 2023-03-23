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

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentAnswerDal : GenericRepository<CommentAnswer>, ICommentAnswerDal
    {
        public EfCommentAnswerDal(WithCodesContext context) : base(context)
        {
        }
    }
}
