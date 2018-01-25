using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Converters;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using NHibernate.Linq;

namespace Backend.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private IConverter<RoleEntity, Role> EntityModelConverter;
        private IConverter<Role, RoleEntity> ModelEntityConverter;
        private BaseRepository<RoleEntity> BaseRepository;

        public RoleRepository(IConverter<RoleEntity, Role> entityModelConverter, IConverter<Role, RoleEntity> modelEntityConverter)
        {
            EntityModelConverter = entityModelConverter;
            ModelEntityConverter = modelEntityConverter;
            BaseRepository = new BaseRepository<RoleEntity>();
        }

        public bool Delete(Role role)
        {
            return BaseRepository.Delete(ModelEntityConverter.Convert(role));
        }

        public IEnumerable<Role> GetAll()
        {
            var roles = EntityModelConverter.Convert(BaseRepository.GetAll());
                return roles;
            
        }

        public Role GetById(object Id)
        {
            if (null == Id)
                return null;
            var roleId = (long)Id;
            var role = EntityModelConverter.Convert(BaseRepository.GetById(Id));

            return role;
        }

        public Role GetByName(string name)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var role = db.Query<RoleEntity>().Where(r => r.RoleName.Equals(name)).First();
                return EntityModelConverter.Convert(role);
            }
        }

        public object Save(Role role)
        {
            return (long)BaseRepository.Save(ModelEntityConverter.Convert(role));
        }

        public object Update(object Id, Role role)
        {
            return (long)BaseRepository.Update(Id, ModelEntityConverter.Convert(role));
        }
    }
}