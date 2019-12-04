using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Model.Repository
{
    public interface IDataRepository<TEntity, U> where TEntity : class
    {
        IQueryable<TEntity> GetAll();        
        Task<long> Add(TEntity b);
        Task<long> Update(U id, TEntity b);
        Task<long> Delete(U id);
    }
}
