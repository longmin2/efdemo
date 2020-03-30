using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EFCoreDemo.face
{
    public interface IRepository<T> where T : class, new()
    {
        //查询表跟踪
        IQueryable<T> Table { get; }
        //查询不跟踪
        IQueryable<T> TableNoTracking { get; }
        //返回单个实体对
        T GetById(object id);
        //写入
        int Insert(T entity);
        //批量写入
        int InsertMany(IEnumerable<T> list);
        //修改
        int Update(T entity);
        int Delete(T entity);
        int DeleteMany(IEnumerable<T> list);
        int DeleteWhere(Expression<Func<T, bool>> criteria);
    }
}
