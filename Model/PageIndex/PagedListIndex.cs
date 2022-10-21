using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.PageIndex
{
    public class PagedListIndex<T> : List<T>
    {
        public MetaDataIndex MetaData { get; set; }
        public PagedListIndex(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaDataIndex
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };
            AddRange(items);
        }
        public static PagedListIndex<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize).ToList();
            return new PagedListIndex<T>(items, count, pageNumber, pageSize);
        }
    }
}
