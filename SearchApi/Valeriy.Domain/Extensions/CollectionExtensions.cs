using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Valeriy.Domain.Utils;

namespace Valeriy.Domain.Extensions
{
    public static class CollectionExtensions
    {
        public static PagedCollection<T> ToPagedCollection<T>(this IEnumerable<T> data, int page = 0, int count = 0, int total = 0, int totalPages = 0)
        {
            return new PagedCollection<T>()
            {
                Data = new ReadOnlyCollection<T>(data.ToList()),
                Count = count,
                Page = page,
                Total = total,
                TotalPages = totalPages
            };
        }
    }
}