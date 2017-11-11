using System;
using System.Collections.Generic;
using System.Text;
using TvSports.Core.Entities;

namespace TvSports.Core.Interfaces
{
    public interface IService<T> where T:EntityBase
    {
        T CreateOrUpdate<TDb>(T entity, Func<T, bool> p);
    }
}
