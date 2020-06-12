using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dwapi.Hts.SharedKernel.Model;

namespace Dwapi.Hts.SharedKernel.Interfaces
{
    public interface IRepository<T, in TId> where T : Entity<TId>
    {
        string ConnectionString { get; }

        Task<T> GetAsync(TId id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void CreateBulk(IEnumerable<T> entities);
        void UpdateBulk(IEnumerable<T> entities);
        void Save();
        Task<int> SaveAsync();

        int ExecSql(string sql);
        Task<int> ExecSqlAsync(string sql);
        IDbConnection GetDbConnection();
    }
}
