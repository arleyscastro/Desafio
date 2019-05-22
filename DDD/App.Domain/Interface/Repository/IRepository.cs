using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace App.Domain.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> condition);
        TEntity Get(int id);
        TEntity Get(Expression<Func<TEntity, bool>> condition);
        bool Any(Expression<Func<TEntity, bool>> condition);
        TEntity GetUsingSQLCommand(int id);

    }
}
