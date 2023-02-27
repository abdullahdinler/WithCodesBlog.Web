using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfNotificationDal:GenericRepository<Notification>,INotificationDal
    {
        public EfNotificationDal(WithCodesContext context) : base(context)
        {
        }
    }
}
