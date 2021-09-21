using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
