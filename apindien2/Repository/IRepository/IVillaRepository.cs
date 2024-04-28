using apindien2.Models;
using System.Linq.Expressions;

namespace apindien2.Repository.IRepository
{
    public interface IVillaRepository
    {

        Task<List<Villa>> GetAll(Expression<Func<Villa, bool>> filter = null);
        Task<Villa> Get(Expression<Func<Villa, bool>> filter = null, bool tracked = true);
        Task Create(Villa entity);
        Task Remove(Villa entity);
        Task Update(Villa entity);  
        Task Save();
    }
}
