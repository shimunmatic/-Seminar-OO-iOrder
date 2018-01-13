using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>

    {
        public virtual IEnumerable<T> GetAll()
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return db.Query<T>().ToList();
            }
        }

        public virtual T GetById(object Id)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                return db.Get<T>(Id);
            }
        }

        public virtual object Save(T t)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                using (var transaction = db.BeginTransaction())
                {
                    var savedId = db.Save(t);
                    transaction.Commit();
                    return savedId;
                }
            }
        }

        public virtual object Update(object Id, T t)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                var old = db.Get<T>(Id);
                old = t;
                using (var transaction = db.BeginTransaction())
                {
                    db.SaveOrUpdate(old);
                    transaction.Commit();
                    return Id;
                }
            }
        }

        public virtual bool Delete(T t)
        {
            using (var db = NHibernateHelper.OpenSession())
            {
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        db.Delete(t);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
