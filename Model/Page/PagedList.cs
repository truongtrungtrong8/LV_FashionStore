﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Page
{
    public class PagedList<T>
    {
        public MetaData MetaData { get; set; }
        public List<T> Items { get; set; }

        public PagedList() { }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPage = (int)Math.Ceiling(count / (double)pageSize)
            };
            Items = items;
        }
    }
}
