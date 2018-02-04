using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models.Entity.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Backend
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static string ConnectionString =
                "Server=tcp:iorder.database.windows.net,1433;Initial Catalog=iorderDB;Persist Security Info=False;User ID=shimun;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            ;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(ConnectionString))
                        // .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                        .Mappings(m =>
                        {
                            m.FluentMappings.Add<RoleMap>();
                            m.FluentMappings.Add<UserMap>();
                            m.FluentMappings.Add<CategoryMap>();
                            m.FluentMappings.Add<EstablishmentMap>();
                            m.FluentMappings.Add<ProductMap>();
                            m.FluentMappings.Add<LocationMap>();
                            m.FluentMappings.Add<OrderMap>();
                            m.FluentMappings.Add<OrderPairMap>();
                            m.FluentMappings.Add<WarehouseMap>();
                            m.FluentMappings.Add<WarehouseProductMap>();
                            m.FluentMappings.Add<SupplierMap>();
                        })
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