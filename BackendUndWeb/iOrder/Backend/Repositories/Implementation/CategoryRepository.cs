using Backend.Converters;
using Backend.Converters.EntityBusiness;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private IConverter<Category, CategoryEntity> ModelEntityConverter;
        private IConverter<CategoryEntity, Category> EntityModelConverter;
        private BaseRepository<CategoryEntity> BaseRepository;

        public CategoryRepository(IConverter<Category, CategoryEntity> modelEntityConverter, IConverter<CategoryEntity, Category> entityModelConverter)
        {
            ModelEntityConverter = modelEntityConverter;
            EntityModelConverter = entityModelConverter;
            BaseRepository = new BaseRepository<CategoryEntity>();
        }

        public bool Delete(Category t)
        {
            return BaseRepository.Delete(ModelEntityConverter.Convert(t));
        }

        public IEnumerable<Category> GetAll()
        {
            return EntityModelConverter.Convert(BaseRepository.GetAll());
        }

        public Category GetById(object Id)
        {
            return EntityModelConverter.Convert(BaseRepository.GetById(Id));
        }

        public IEnumerable<Category> GetCategoriesOfOwner(string username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var entities = db.Query<CategoryEntity>().Where(c => c.OwnerId.Equals(username));
                return EntityModelConverter.Convert(entities);

            }
        }

        public object Save(Category t)
        {
            return BaseRepository.Save(ModelEntityConverter.Convert(t));
        }

        public object Update(object Id, Category t)
        {
            return BaseRepository.Update(Id, ModelEntityConverter.Convert(t));
        }

    }
}
