using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using Dwapi.Hts.SharedKernel.Interfaces;
using Dwapi.Hts.SharedKernel.Model;
using Microsoft.EntityFrameworkCore;
using Z.Dapper.Plus;

namespace Dwapi.Hts.SharedKernel.Infrastructure.Data
{
    public abstract class BaseRepository<T, TId> : IRepository<T, TId> where T : Entity<TId>
    {
        protected internal DbContext Context;
        protected internal DbSet<T> DbSet;

        protected BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public string ConnectionString => GetDbConnection().ConnectionString;

        public virtual Task<T> GetAsync(TId id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking();
        }

        public virtual void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void CreateBulk(IEnumerable<T> entities)
        {
            using (var cn=new SqlConnection(ConnectionString))
            {
                cn.BulkInsert(entities);
            }
        }

        public virtual void UpdateBulk(IEnumerable<T> entities)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.BulkUpdate(entities);
            }
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }

        public int ExecSql(string sql)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                cn.Execute(sql,null,null,0);
            }
            return 1;
        }

        public virtual async Task<int> ExecSqlAsync(string sql)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                await cn.ExecuteAsync(sql,null,null,0);
            }
            return 1;
        }

        public IDbConnection GetDbConnection()
        {
            return Context.Database.GetDbConnection();
        }
    }
}
