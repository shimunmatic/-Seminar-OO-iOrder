using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Converters
{
    public interface IConverter<T, J>
    {

        J Convert(T Source);
        IEnumerable<J> Convert(IEnumerable<T> Source);

    }
}
