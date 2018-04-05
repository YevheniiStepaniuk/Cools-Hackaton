using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Valeriy.Domain.Extensions
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<Exception> GetInnerExceptions(this Exception ex)
        {
            yield return ex;
            while (ex.InnerException != null)
            {
                yield return ex.InnerException;
            }
        }
    }
}