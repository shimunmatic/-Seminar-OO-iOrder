using Backend.Converters;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories.Implementation
{
    public class SupplierRepository : ISupplierRepository
    {
        private IConverter<SupplierEntity, Supplier> EntityModel;
        private IConverter<Supplier, SupplierEntity> ModelEntity;
        private BaseRepository<SupplierEntity> BaseRepository;

        public SupplierRepository(IConverter<SupplierEntity, Supplier> entityModel, IConverter<Supplier, SupplierEntity> modelEntity)
        {
            EntityModel = entityModel;
            ModelEntity = modelEntity;
            BaseRepository = new BaseRepository<SupplierEntity>();
        }

        public bool Delete(Supplier t) => BaseRepository.Delete(ModelEntity.Convert(t));

        public IEnumerable<Supplier> GetAll() => EntityModel.Convert(BaseRepository.GetAll());

        public Supplier GetById(object Id) => EntityModel.Convert(BaseRepository.GetById(Id));

        public IEnumerable<Supplier> GetSuppliersForOwner(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModel.Convert(db.Query<SupplierEntity>().Where(s => s.OwnerId.Equals(Username)).ToList());
            }
        }

        public object Save(Supplier t) => (long)BaseRepository.Save(ModelEntity.Convert(t));

        public object Update(object Id, Supplier t) => (long)(BaseRepository.Update(Id, ModelEntity.Convert(t)));
    }
}
