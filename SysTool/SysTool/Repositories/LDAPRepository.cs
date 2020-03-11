using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTool.Repositories
{
    public class LDAPRepository<T> : IRepository<T>
        where T : class, new()
    {
        public int Edit(T instance, string className, string condition)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(string className, string condition)
        {
            throw new NotImplementedException();
        }
    }
}
