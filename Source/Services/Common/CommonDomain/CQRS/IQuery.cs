using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDomain.CQRS
{
    /// <summary>
    /// Allow other application/domain retrieve data from domain
    /// </summary>
    /// <typeparam name="TResult">Type of input parameters</typeparam>
    public interface IQuery<TResult>
    {
    }
}
