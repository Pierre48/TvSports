﻿using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;

namespace TvSports.Core.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id, params string[] includes);
        T GetSingleBySpec(ISpecification<T> spec);
        IEnumerable<T> ListAll(params string[] includes);
        IEnumerable<T> ListAll(int startIndex, int nbToTake, params string[] includes);
        IEnumerable<T> List(ISpecification<T> spec,int startIndex, int nbToTake, params string[] includes);
        IEnumerable<T> List(ISpecification<T> spec);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
