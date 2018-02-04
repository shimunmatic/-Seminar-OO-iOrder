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
    public class UserRepository : IUserRepository
    {
        private IConverter<UserEntity, User> EntityModelConverter;
        private IConverter<User, UserEntity> ModelEntityConverter;
        private IConverter<RoleEntity, Role> RoleConverter;
        private BaseRepository<UserEntity> BaseRepository;

        public UserRepository(IConverter<UserEntity, User> entityModelConverter, IConverter<User, UserEntity> modelEntityConverter
            , IConverter<RoleEntity, Role> roleConverter)
        {
            EntityModelConverter = entityModelConverter;
            ModelEntityConverter = modelEntityConverter;
            RoleConverter = roleConverter;
            BaseRepository = new BaseRepository<UserEntity>();
        }

        public bool Delete(User user)
        {
            return BaseRepository.Delete(ModelEntityConverter.Convert(user));
        }


        public IEnumerable<User> GetAll()
        {
            var usersEntity = BaseRepository.GetAll();
            var users = new List<User>();
            foreach (var u in usersEntity)
            {
                var user = EntityModelConverter.Convert(u);
                user.Role = GetRole(u.RoleId);
                users.Add(user);
            }
            return users;
        }

        public User GetById(object Id)
        {
            var userEntity = BaseRepository.GetById(Id);
            if (null == userEntity) return null;
            var user = EntityModelConverter.Convert(userEntity);
            user.Role = GetRole(userEntity.RoleId);
            return user;
        }

        public IEnumerable<User> GetByRole(long roleId)
        {
            using (var db = NHibernateHelper.OpenSession())
            {

                var entities = db.Query<UserEntity>().Where(u => u.RoleId == roleId).ToList();
                var users = new List<User>();
                foreach (var u in entities)
                {
                    var user = EntityModelConverter.Convert(u);
                    user.Role = GetRole(u.RoleId);
                    users.Add(user);
                }
                return users;
            }
        }

        public IEnumerable<User> GetEmployeesOfEsatblishemnt(long Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {

                var entities = db.Query<UserEntity>().Where(u => u.EstablishmentId == Id).ToList();
                var users = new List<User>();
                foreach (var u in entities)
                {
                    var user = EntityModelConverter.Convert(u);
                    user.Role = GetRole(u.RoleId);
                    users.Add(user);
                }
                return users;
            }
        }

        public IEnumerable<User> GetEmployeesOfOwner(string username)
        {
            using (var db = NHibernateHelper.OpenSession())
            {

                var entities = db.Query<UserEntity>().Where(u => u.OwnerId.Equals(username)).ToList();
                var users = new List<User>();
                foreach (var u in entities)
                {
                    var user = EntityModelConverter.Convert(u);
                    user.Role = GetRole(u.RoleId);
                    users.Add(user);
                }
                return users;
            }
        }

        public object Save(User user)
        {

            return (string)BaseRepository.Save(ModelEntityConverter.Convert(user));

        }

        public object Update(object Id, User t)
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
