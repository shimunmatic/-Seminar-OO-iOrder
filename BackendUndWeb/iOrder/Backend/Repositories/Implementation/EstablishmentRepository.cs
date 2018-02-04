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
    public class EstablishmentRepository : IEstablishmentRepository
    {
        private IConverter<Establishment, EstablishmentEntity> ModelEntityConverter;
        private IConverter<EstablishmentEntity, Establishment> EntityModelConverter;
        private BaseRepository<EstablishmentEntity> BaseRepository;

        public EstablishmentRepository(IConverter<Establishment, EstablishmentEntity> modelEntityConverter, IConverter<EstablishmentEntity, Establishment> entityModelConverter)
        {
            ModelEntityConverter = modelEntityConverter;
            EntityModelConverter = entityModelConverter;
            BaseRepository = new BaseRepository<EstablishmentEntity>();
        }

        public bool Delete(Establishment t)
        {
            return BaseRepository.Delete(ModelEntityConverter.Convert(t));
        }

        public IEnumerable<Establishment> GetAll()
        {
            return EntityModelConverter.Convert(BaseRepository.GetAll());
        }

        public Establishment GetById(object Id)
        {
            return EntityModelConverter.Convert(BaseRepository.GetById(Id));
        }


        public IEnumerable<Establishment> GetEstablishmentsForOwner(string Username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModelConverter.Convert(db.Query<EstablishmentEntity>().Where(e => e.OwnerId.Equals(Username)).ToList());
            }
        }

        public IEnumerable<Establishment> GetEstablishmentsForWarehouse(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModelConverter.Convert(db.Query<EstablishmentEntity>().Where(e => e.WarehouseId.Equals(Id)).ToList());
            }
        }

        public object Save(Establishment t)
        {
            return (long)BaseRepository.Save(ModelEntityConverter.Convert(t));
        }

        public object Update(object Id, Establishment t)
        {
            return (long) BaseRepository.Update(Id, ModelEntityConverter.Convert(t));
        }
    }
}
