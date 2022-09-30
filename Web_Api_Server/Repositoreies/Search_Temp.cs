using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Server.Repositoreies
{
    public static class Search_Temp
    {
        public static IQueryable<Sanpham_Model> Search(this IQueryable<Sanpham_Model> products, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return products;

            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();

            return products.Where(p => p.TenSp.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
