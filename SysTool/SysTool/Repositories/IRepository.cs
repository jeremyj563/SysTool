using System.Linq;

namespace SysTool.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Get(string className, string condition);
    }
}
