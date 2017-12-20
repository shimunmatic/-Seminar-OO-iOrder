using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate.Criterion;

namespace Backend.Models.Entity.Mappings
{
    public class UserMap : ClassMap<UserEntity>
    {
        public UserMap()
        {
            Table("[user]");
            Schema("dbo");
            Id(u => u.Username).Column("username");
            Map(u => u.Email).Column("email");
            Map(u => u.Password).Column("password");
            Map(u => u.FirstName).Column("first_name");
            Map(u => u.LastName).Column("last_name");
            Map(u => u.RoleId).Column("roleID");
        }
    }
}
