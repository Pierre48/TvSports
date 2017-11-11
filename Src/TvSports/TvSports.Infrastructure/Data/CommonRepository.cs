using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TvSports.Core.Extensions;
using TvSports.Core.Interfaces;

namespace TvSports.Infrastructure.Data
{

    public class CommonRepository<T> : ICommonRepository<T> where T:class
    {
        protected readonly TvSportsContext _dbContext;

        public CommonRepository(TvSportsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetSingleByFilter(Func<T, bool> filter, params string[] includes)
        {
            IQueryable<T> set = _dbContext.Set<T>().Where(t => filter(t));
            includes?.ForEach(i =>
            {
                set = set.Include(i);
            });
            return set.FirstOrDefault();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
