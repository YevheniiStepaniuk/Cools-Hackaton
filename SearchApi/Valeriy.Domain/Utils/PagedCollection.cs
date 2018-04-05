using System.Collections.Generic;

namespace Valeriy.Domain.Utils
{
    public class PagedCollection<T>
    {
        public IReadOnlyCollection<T> Data { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }
}