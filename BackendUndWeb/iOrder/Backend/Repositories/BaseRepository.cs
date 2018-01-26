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
            var t = new Object();
            using (var db = NHibernateHelper.OpenSession())
            {
                t = db.Get<T>(Id);
            }
            return (T) t;
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
                using (var transaction = db.BeginTransaction())
                {
                    db.Update(t);
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
