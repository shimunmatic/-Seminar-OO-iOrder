using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Converters.EntityBusiness.Interface;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using NHibernate.Linq;

namespace Backend.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRoleConverter RoleConverter;

        public RoleRepository(IRoleConverter converter)
        {
            RoleConverter = converter;
        }
        public IEnumerable<Role> GetAll()
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var roles = RoleConverter.convert(db.Query<RoleEntity>().ToList());
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
    }
}