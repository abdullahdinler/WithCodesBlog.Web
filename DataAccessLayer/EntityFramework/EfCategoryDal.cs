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
    public class EfCategoryDal:GenericRepository<Category>,ICategoryDal
    {
        private readonly WithCodesContext _context;
        public EfCategoryDal(WithCodesContext context) : base(context)
        {
            _context = context;
        }

    }
}
