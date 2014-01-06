using System.Linq;

namespace poc.Models
{
    public interface IStorage
    {
        IQueryable<T> StorageFor<T>() where T : class;
        void Add<T>(T entity) where T : class;
    }
}