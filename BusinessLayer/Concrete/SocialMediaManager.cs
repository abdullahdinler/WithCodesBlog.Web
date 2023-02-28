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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public List<SocialMedia>? GetAllList()
        {
            return _socialMediaDal.GetAll();
        }

        public SocialMedia? Get(int id)
        {
            return _socialMediaDal.GetById(x => x.Id == id);
        }

        public void Add(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void Update(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }

        public void Delete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }
    }
}
