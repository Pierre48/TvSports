﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvSports.Core.Entities;
using TvSports.Core.Extensions;
using TvSports.Core.Interfaces;

namespace TvSports.Infrastructure.Data
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : EntityBase
    {
        protected readonly TvSportsContext _dbContext;

        public EfRepository(TvSportsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id, params string[] includes)
        {
            IQueryable<T> set = _dbContext.Set<T>();
            includes?.ForEach(i =>
            {
                set = set.Include(i);
            });
            return set.FirstOrDefault(x => x.Id == id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }


        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ListAll(params string[] includes)
        {
            IQueryable<T> set = _dbContext.Set<T>();
            includes?.ForEach(i =>
            {
                set = set.Include(i);
            });
            return set.AsEnumerable();
        }

        public IEnumerable<T> List(ISpecification<T> spec, int startIndex, int nbToTake, params string[] includes)
        {
            IQueryable<T> set = ListQueryable(spec);
            includes?.ForEach(i =>
            {
                set = set.Include(i);
            });
            return set.Skip(startIndex).Take(nbToTake).AsEnumerable();
        }

        public IEnumerable<T> ListAll(int startIndex, int nbToTake, params string[] includes)
        {
            IQueryable<T> set = _dbContext.Set<T>();
            includes?.ForEach(i =>
            {
                set = set.Include(i);
            });
            return set.Skip(startIndex).Take(nbToTake).AsEnumerable();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            return ListQueryable(spec).AsQueryable();
        }

        private IQueryable<T> ListQueryable(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria);
        }
        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public T GetSingle(Func<T, bool> p, params string[] includes)
        {
            IQueryable<T> set = _dbContext.Set<T>().Where(t => p(t));
            includes?.ForEach(i =>
            {
                set = set.Include(i);
            });
            return set.FirstOrDefault();
        }

    }
}
