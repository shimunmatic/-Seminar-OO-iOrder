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
        private BaseRepository<UserEntity> BaseRepository;

        public UserRepository(IConverter<UserEntity, User> entityModelConverter, IConverter<User, UserEntity> modelEntityConverter)
        {
            EntityModelConverter = entityModelConverter;
            ModelEntityConverter = modelEntityConverter;
            BaseRepository = new BaseRepository<UserEntity>();
        }

        public bool Delete(User user)
        {
            return BaseRepository.Delete(ModelEntityConverter.Convert(user));
        }

        public User Get(object Username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public User Save(User user)
        {
            throw new NotImplementedException();
        }

        public User Update(object Id, User t)
        {
            throw new NotImplementedException();
        }
    }
}
