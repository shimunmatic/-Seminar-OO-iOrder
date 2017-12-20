using FluentNHibernate.Mapping;

namespace Backend.Models.Entity.Mappings
{
    public class RoleMap : ClassMap<RoleEntity>
    {
        public RoleMap()
        {
            Table("role");
            Schema("dbo");
            Id(role => role.Id).Column("id");
            Map(role => role.RoleName).Column("role").Not.Nullable();
        }
    }
}
