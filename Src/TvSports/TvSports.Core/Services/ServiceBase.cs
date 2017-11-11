using AutoMapper;
using System;
using TvSports.Core.Entities;
using TvSports.Core.Interfaces;

namespace TvSports.Core.Services
{
    public abstract class ServiceBase<T> : IService<T> where T : EntityBase
    {
        protected IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }
        public T CreateOrUpdate<TDb>(T entity, Func<T, bool> p)
        {
            var entityDb = _repository.GetSingle(t=>p(t));
            if (entityDb == null)
            {
                _repository.Add(entity);
                return entity;
            }
            else
            {
                Map(entity, entityDb);
                _repository.Update(entityDb);
                entity.Id = entityDb.Id;
                return entityDb;
            }
        }

        protected abstract void Map(T entity, T entityDb);
    }
}