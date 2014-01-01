using System.Linq;

namespace poc.Models
{
    public interface IStorage
    {
        IQueryable<T> StorageFor<T>() where T : class;
        T Add<T>(T entity) where T : class;
        T Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
    }
}