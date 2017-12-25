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
            using (var db = NHibernateHelper.OpenSession())
            {
                var roles = EntityModelConverter.Convert(db.Query<RoleEntity>().ToList());
                var users = db.Query<UserEntity>().ToList();
                foreach (var role in roles)
                {
                    role.Users = (from user in users
                                  where user.RoleId == role.Id
                                  select user).ToList();
                }
                return roles;
            }
        }

        public Role GetById(long Id)
        {
            var role = EntityModelConverter.Convert(BaseRepository.GetById(Id));

            using (var db = NHibernateHelper.OpenSession())
            {
                var users = db.Query<UserEntity>().Where(user => user.RoleId == Id);
                role.Users = users;
                return role;
            }
        }

        public Role GetByName(string name)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var role = db.Query<RoleEntity>().Where(r => r.RoleName.Equals(name)).First();
                return EntityModelConverter.Convert(role);
            }
        }

        public Role Save(Role role)
        {
            return EntityModelConverter.Convert(BaseRepository.Save(ModelEntityConverter.Convert(role)));
        }

        public Role Update(long Id, Role role)
        {
            return EntityModelConverter.Convert(BaseRepository.Update(Id, ModelEntityConverter.Convert(role)));
        }
    }
}