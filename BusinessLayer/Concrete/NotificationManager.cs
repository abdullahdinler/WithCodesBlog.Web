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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification>? GetAllList()
        {
            return _notificationDal.GetAll();
        }

        public Notification? Get(int id)
        {
            return _notificationDal.GetById(x => x.Id == id);
        }

        public void Add(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }

        public void Delete(Notification entity)
        {
           _notificationDal.Delete(entity);
        }
    }
}
