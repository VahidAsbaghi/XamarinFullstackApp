using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zave.Torbat.Siman.Model.DbContexts;

namespace Zave.Torbat.Siman.Model.Repositories
{
    public class GenericRepository<T>: IRepositoryBase where T : class
    {
        protected readonly DbSet<T> Set;
        private readonly IDataContext _dataContext;

        public GenericRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
            Set = _dataContext.GetDbSet<T>();
        }

        public IQueryable<T> All()
        {
            return Set.AsQueryable();
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = All();

            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public T FirstOrDefault()
        {
            return All().FirstOrDefault();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return All().FirstOrDefault(predicate);
        }

        public Task<T> FirstOrDefaultAsync()
        {
            return All().FirstAsync();
        }

        public Task<T> FirstOrDefaultAsync(CancellationToken cancellationToken)
        {
            return All().FirstAsync(cancellationToken);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return All().FirstAsync(predicate);
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return All().FirstAsync(predicate, cancellationToken);
        }

        public T FindById(string id)
        {
            return Set.Find(id);
        }
        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Attach(T entity)
        {
            Set.Attach(entity);
            //_dataContext.GetEntry(entity).State = EntityState.Modified;
            //_dataContext.SaveChanges();
        }

        //public void Detatch(T entity)
        //{
            
        //    _dataContext.GetEntry(entity).State = EntityState.Detached;
        //}

        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> criteria)
        {
            var entities = Where(criteria).ToList();

            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities.ToList())
            {
                Delete(entity);
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> criteria)
        {
            return Set.Where(criteria);
        }

        public int Count()
        {
            return Set.Count();
        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return Set.Count(criteria);
        }

        public Task<int> CountAsync()
        {
            return Set.CountAsync();
        }

        public Task<int> CountAsync(CancellationToken cancellationToken)
        {
            return Set.CountAsync(cancellationToken);
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return Set.CountAsync(criteria);
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken)
        {
            return Set.CountAsync(criteria, cancellationToken);
        }

        public Task<int> SaveChangesAsync()
        {
            return  _dataContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }
    }

    public interface IRepositoryBase
    {
    }
}
