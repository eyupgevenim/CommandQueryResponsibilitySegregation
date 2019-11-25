using CommandQueryResponsibilitySegregation.Infrastructure.DbContexts;
using CommandQueryResponsibilitySegregation.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CommandQueryResponsibilitySegregation.Infrastructure.Repository
{
    public class Repository<T> : IQueryRepository<T>, ICommandRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("AppDbContext can not be null");

            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T GetById(int id) => _dbSet.Find(id);

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
            => predicate == null ? _dbSet : _dbSet.Where(predicate);

        public void Add(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save() => _dbContext.SaveChanges();
    }
}
