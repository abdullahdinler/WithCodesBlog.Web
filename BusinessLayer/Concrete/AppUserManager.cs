﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AppUserManager:IAppUserService
    {
        private readonly IAppUserDal _appUser;

        public AppUserManager(IAppUserDal appUser)
        {
            _appUser = appUser;
        }

        public List<AppUser>? GetAllList()
        {
            return _appUser.GetAll(x=>x.Blogs!.Count > 0);
        }

        public AppUser? Get(int id)
        {
            return _appUser.GetById(x => x.Id == id);
        }

        public void Add(AppUser entity)
        {
           _appUser.Add(entity);
        }

        public void Update(AppUser entity)
        {
            _appUser.Update(entity);
        }

        public void Delete(AppUser entity)
        {
            _appUser.Delete(entity);
        }

        public List<AppUser>? Search(string search)
        {
            return _appUser.GetAll(x => x.NameSurname != null && x.NameSurname.Contains(search));
        }
    }
}
