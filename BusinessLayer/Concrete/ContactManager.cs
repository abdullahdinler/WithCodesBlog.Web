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
    public class ContactManager:IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact>? GetAllList()
        {
            return _contactDal.GetAll();
        }

        public Contact? Get(int id)
        {
            return _contactDal.GetById(x => x.Id == id);
        }

        public void Add(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);
        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public List<Contact>? SearchContacts(string search)
        {
            return _contactDal.GetAll(x => x.FullName != null && x.FullName.Contains(search));
        }
    }
}
