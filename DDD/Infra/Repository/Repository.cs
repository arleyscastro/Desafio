using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using App.Domain.Interface.Repository;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _appDbContext;
        public DbSet<TEntity> _DbSet;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _DbSet = _appDbContext.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            _DbSet.Add(entity);
            _appDbContext.SaveChanges();
            return entity;
        }

        public virtual void Update(TEntity entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _DbSet.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _DbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> condition)
        {
            return _DbSet.Where(condition).AsEnumerable();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> condicao)
        {
            return _DbSet.FirstOrDefault(condicao);
        }

        public bool Any(Expression<Func<TEntity, bool>> condition)
        {
            return _DbSet.Any(condition);
        }

        public TEntity GetUsingSQLCommand(int id)
        {
            IList<TEntity> T = new List<TEntity>();

            using (var conn = _appDbContext.Database.GetDbConnection())
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    string nomeEntidade = typeof(TEntity).Name;
                    command.CommandText = $"SELECT * FROM {nomeEntidade} where Id{nomeEntidade} = @id";
                    SqlParameter sqlParameter = new SqlParameter("@id", id);
                    command.Parameters.Add(sqlParameter);

                    var prop = typeof(TEntity).GetProperties();
                    TEntity model;
                    object val;

                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            model = (TEntity)Activator.CreateInstance(typeof(TEntity));
                            int i = 0;
                            foreach (var linha in prop)
                            {
                                if (result.FieldCount == i)
                                {
                                    break;
                                }

                                val = result[linha.Name];
                                if (val == DBNull.Value)
                                {
                                    linha.SetValue(model, null);
                                }
                                else
                                {
                                    linha.SetValue(model, val);
                                }

                                i++;
                            }
                            T.Add(model);
                        }
                    }
                }
            }

            return T.FirstOrDefault();
        }

        public virtual TEntity Get(int id)
        {
            return _DbSet.Find(id);
        }
    }
}
