using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Entity;
using Backend.Repositories.Interface;
using NHibernate.Linq;

namespace Backend.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        public IEnumerable<RoleEntity> GetAll()
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return db.Query<RoleEntity>().ToList();
            }
        }
    }
}