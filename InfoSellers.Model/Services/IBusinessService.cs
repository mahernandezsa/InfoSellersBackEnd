using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Model.Services
{
    public interface IBusinessService<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<long> Add(TEntity b);
        Task<long> Update(U id, TEntity b);
        Task<long> Delete(U id);
        Task<TEntity> GetById(U id);
    }
}
