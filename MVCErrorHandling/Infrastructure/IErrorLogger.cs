using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCErrorHandling.Infrastructure
{
    interface IErrorLogger<T> where T :class
    {
        void Log(T entity);

    }
}
