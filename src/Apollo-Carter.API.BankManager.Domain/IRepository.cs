using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/*
 * Repository: Mediates between the domain and data mapping layers 
 * using a collection-like interface for accessing domain objects. 
 * https://martinfowler.com/eaaCatalog/repository.html
 * 
 * This is a generic interface for repositories to be used
 */

namespace Apollo_Carter.API.BankManager.Domain
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> FindById(Guid id);
        Task<TEntity> FindAll();
        Task<TEntity> Add(TEntity entity);
        Task Remove(string id);
    }
}
