using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace AG.TweeterApp
{
    public interface IRepository<T>
    {
        
        //IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetByName(string name);
    }
}