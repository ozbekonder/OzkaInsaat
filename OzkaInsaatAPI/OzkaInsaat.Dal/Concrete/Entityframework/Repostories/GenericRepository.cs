using Microsoft.EntityFrameworkCore;
using OzkaInsaat.Dal.Abstract;
using OzkaInsaat.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OzkaInsaat.Dal.Concrete.Entityframework.Repostories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Variables
        protected DbContext context;
        protected DbSet<T> dbset;
        #endregion

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbset = this.context.Set<T>();

            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public List<T> TGetList()
        {
            return dbset.ToList();
        }
        public T TgetItemByID(int key)
        {
            return dbset.Find(key);
        }
        public int TAdd(T p)
        {
            context.Entry(p).State = EntityState.Added;
            dbset.Add(p);
            return context.SaveChanges();
        }
        public void TUpdate(T p)
        {
            dbset.Update(p);
            context.SaveChanges();
        }
        public void TDelete(T p)
        {
            if (context.Entry(p).State == EntityState.Detached)
                context.Attach(p);
            dbset.Remove(p);
            context.SaveChanges();
        }
        public void SaveChange()
        {
            context.SaveChanges();
        }
    }
}
