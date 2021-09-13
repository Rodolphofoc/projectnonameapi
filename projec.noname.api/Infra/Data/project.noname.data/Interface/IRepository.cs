using System.Collections.Generic;

namespace project.noname.data.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FirstOfDefault<TEntity>(string query, object param = null);

        IEnumerable<TEntity> GetAll<TEntity>(string query, object param = null);

    }
}
