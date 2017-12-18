using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Entity.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Backend
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(
                                "Server=tcp:shimun.database.windows.net,1433;Initial Catalog=iOrderDB;Persist Security Info=False;User ID=server;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                        // .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                        .Mappings(m => m.FluentMappings.Add<RoleMap>())
                        .ExposeConfiguration(config =>
                        {
                            SchemaExport schemaExport = new SchemaExport(config);
                        })
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
