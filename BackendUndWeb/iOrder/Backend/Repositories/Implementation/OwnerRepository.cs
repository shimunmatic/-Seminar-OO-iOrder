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
    public class OwnerRepository : IOwnerRepository
    {
        private IConverter<OwnerEntity, Owner> EntityModelConverter;
        private IConverter<Owner, OwnerEntity> ModelEntityConverter;
        private IConverter<RoleEntity, Role> RoleConverter;
        private BaseRepository<OwnerEntity> BaseRepository;

        public OwnerRepository(IConverter<OwnerEntity, Owner> entityModelConverter, IConverter<Owner, OwnerEntity> modelEntityConverter
            , IConverter<RoleEntity, Role> roleConverter)
        {
            EntityModelConverter = entityModelConverter;
            ModelEntityConverter = modelEntityConverter;
            RoleConverter = roleConverter;
            BaseRepository = new BaseRepository<OwnerEntity>();
        }

        public bool Delete(Owner t)
        {
            return BaseRepository.Delete(ModelEntityConverter.Convert(t));
        }

        public IEnumerable<Owner> GetAll()
        {
            var ownerEntities = BaseRepository.GetAll();
            var owners = new List<Owner>();
            foreach (var o in ownerEntities)
            {
                var owner = EntityModelConverter.Convert(o);
                owner.Role = GetRole(o.RoleId);
                owners.Add(owner);
            }
            return owners;
        }

        public Owner GetById(object Id)
        {
            var ownerEntity = BaseRepository.GetById(Id);
            var owner = EntityModelConverter.Convert(ownerEntity);
            owner.Role = GetRole(ownerEntity.RoleId);
            return owner;
        }

        public object Save(Owner t)
        {
            return (string)BaseRepository.Save(ModelEntityConverter.Convert(t));

        }

        public object Update(object Id, Owner t)
        {

            return (string)BaseRepository.Update(Id, ModelEntityConverter.Convert(t));

        }

        private Role GetRole(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return RoleConverter.Convert(db.Query<RoleEntity>().Where(r => r.Id == Id).First());
            }
        }
    }
}
