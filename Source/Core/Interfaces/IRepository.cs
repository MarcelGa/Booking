using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);

        Task<ICollection<T>> Get(); 

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);
    }
}
