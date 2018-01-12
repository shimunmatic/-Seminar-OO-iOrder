using Backend.Converters;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repositories.Implementation
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private IConverter<Warehouse, WarehouseEntity> ModelEntity;
        private IConverter<WarehouseEntity, Warehouse> EntityModel;
        private BaseRepository<WarehouseEntity> BaseRepository;

        public WarehouseRepository(IConverter<Warehouse, WarehouseEntity> modelEntity, IConverter<WarehouseEntity, Warehouse> entityModel)
        {
            ModelEntity = modelEntity;
            EntityModel = entityModel;
            BaseRepository = new BaseRepository<WarehouseEntity>();
        }

        public bool Delete(Warehouse t) => BaseRepository.Delete(ModelEntity.Convert(t));
        public IEnumerable<Warehouse> GetAll() => EntityModel.Convert(BaseRepository.GetAll());

        public Warehouse GetById(object Id) => EntityModel.Convert(BaseRepository.GetById(Id));

        public IEnumerable<Warehouse> GetWearhousesForOwner(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModel.Convert(db.Query<WarehouseEntity>().Where(w => w.OwnerId.Equals(Username)));
            }
        }

        public object Save(Warehouse t) => (long)BaseRepository.Save(ModelEntity.Convert(t));

        public object Update(object Id, Warehouse t) => (long)BaseRepository.Update(Id, ModelEntity.Convert(t));
    }
}
