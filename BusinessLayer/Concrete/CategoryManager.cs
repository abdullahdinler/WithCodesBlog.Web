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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category>? GetAllList()
        {
            return _categoryDal.GetAll();
        }

        public Category? Get(int id)
        {
            return _categoryDal.GetById(x => x.Id == id);
        }

        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public void Delete(Category entity)
        {
           _categoryDal.Delete(entity);
        }
    }
}
