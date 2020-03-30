using EFCoreDemo.Entity;
using EFCoreDemo.face;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EFCoreDemo.service
{
    public class RepositoryService<T> : IRepository<T> where T : class, new()
    {
        private Context Context;
        public RepositoryService(Context context)
        {
            Context = context;
        }
        public IQueryable<T> Table => Context.Set<T>().AsQueryable();

        public IQueryable<T> TableNoTracking => Context.Set<T>().AsNoTracking();

        public int Delete(T entity)
        {
            try
            {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteMany(IEnumerable<T> list)
        {
            try
            {
                Context.RemoveRange(list);
                Context.SaveChanges();
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteWhere(Expression<Func<T, bool>> criteria)
        {
            try
            {
                IQueryable<T> entities = Context.Set<T>().Where(criteria);
                foreach (var entity in entities)
                {
                    Context.Entry(entity).State = EntityState.Deleted;
                }
              
                Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }


        }
        //根据主键查单个
        public T GetById(object id)
        {
            return Context.Set<T>().Find(id);
        }

        public int Insert(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int InsertMany(IEnumerable<T> list)
        {
            try
            {
                Context.Set<T>().AddRange(list);
                Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Update(T entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
