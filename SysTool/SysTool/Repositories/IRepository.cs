﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysTool.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Get(string className, string condition);
        int Edit(T instance, string className, string condition);
    }
}
