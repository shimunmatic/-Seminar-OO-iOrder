using Backend.Models.Business;
using Backend.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class UserModelToEntityConverter : IConverter<User, UserEntity>
    {
        public UserEntity Convert(User Source)
        {
            if (null == Source) return null;
            return new UserEntity()
            {
                Username = Source.Username,
                Email = Source.Email,
                FirstName = Source.FirstName,
                LastName = Source.LastName,
                Password = Source.Password,
                RoleId = Source.Role.Id,
                EstablishmentId = Source.EstablishmentId
            };

        }

        public IEnumerable<UserEntity> Convert(IEnumerable<User> Source)
        {
            if (null == Source) return null;
            var users = new List<UserEntity>();
            foreach (var user in Source)
            {
                users.Add(new UserEntity()
                {
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    RoleId = user.Role.Id
                });
            }
            return users;

        }
    }
}
