using Backend.Models.Entity;
using Backend.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters.EntityBusiness
{
    public class UserEntityToModelConverter : IConverter<UserEntity, User>
    {
        public User Convert(UserEntity Source)
        {
            if (null == Source) return null;
            return new User
            {
                Username = Source.Username,
                Email = Source.Email,
                FirstName = Source.FirstName,
                LastName = Source.LastName,
                Password = Source.Password,
                Role = null
            };
        }

        public IEnumerable<User> Convert(IEnumerable<UserEntity> Source)
        {
            if (null == Source) return null;
            var users = new List<User>();
            foreach (var user in Source)
            {
                users.Add(new User
                {
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    Role = null
                });
            }
            return users;

        }
    }
}
