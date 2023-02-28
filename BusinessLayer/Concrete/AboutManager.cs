using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Concrete
{
    public class AboutManager:IAboutService
    {
       
        private readonly IAboutDal _about;

        public AboutManager(IAboutDal about)
        {
            
            _about = about;
        }

        public List<About>? GetAllList()
        {
            return _about.GetAll();
        }

        public About? Get(int id)
        {
            return _about.GetById(x=>x.Id == id);
        }

        public void Add(About entity)
        {
            _about.Add(entity);
        }

        public void Update(About entity)
        {
            _about.Update(entity);
        }

        public void Delete(About entity)
        {
            _about.Delete(entity);
        }
    }
}
