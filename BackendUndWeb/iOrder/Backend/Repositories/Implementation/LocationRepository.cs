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
    public class LocationRepository : ILocationRepository
    {
        private IConverter<Location, LocationEntity> ModelEntityConverter;
        private IConverter<LocationEntity, Location> EntityModelConverter;
        private BaseRepository<LocationEntity> BaseRepository;

        public LocationRepository(IConverter<Location, LocationEntity> modelEntityConverter, IConverter<LocationEntity, Location> entityModelConverter)
        {
            ModelEntityConverter = modelEntityConverter;
            EntityModelConverter = entityModelConverter;
            BaseRepository = new BaseRepository<LocationEntity>();
        }

        public bool Delete(Location t)
        {
            return BaseRepository.Delete(ModelEntityConverter.Convert(t));

        }

        public IEnumerable<Location> GetAll()
        {
            return EntityModelConverter.Convert(BaseRepository.GetAll());
        }

        public Location GetById(object Id)
        {
            return EntityModelConverter.Convert(BaseRepository.GetById(Id));
        }

        public IEnumerable<Location> GetLocationsForEstablishment(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return EntityModelConverter.Convert(db.Query<LocationEntity>().Where(l => l.EstablishmentId == Id).ToList());
            }
        }

        public IEnumerable<Location> GetLocationsForOwnerId(string username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var establishmentForUser = db.Query<EstablishmentEntity>().Where(e => e.OwnerId.Equals(username)).Select(s => s.Id).ToList();
                return EntityModelConverter.Convert(db.Query<LocationEntity>().Where(l => establishmentForUser.Contains(l.EstablishmentId)).ToList());
            }
        }

        public object Save(Location t)
        {
            return (long)BaseRepository.Save(ModelEntityConverter.Convert(t));
        }

        public object Update(object Id, Location t)
        {
            return (long)BaseRepository.Update(Id, ModelEntityConverter.Convert(t));
        }
    }
}
