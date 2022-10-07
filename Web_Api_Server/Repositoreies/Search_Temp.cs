using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace Web_Api_Server.Repositoreies
{
    public static class Search_Temp
    {
     
        public static IQueryable<Sanpham_Model> Search(this IQueryable<Sanpham_Model> products, string search)
        {

            if (string.IsNullOrWhiteSpace(search))
                return products;
            var productsTemp = new List<Sanpham_Model>();
            foreach (var product in products)
            {
                var lowerCaseSearchTerm = ConvertToUnSign3(search.Trim().ToLower());
                if (ConvertToUnSign3(product.TenSp.ToLower()).Contains(lowerCaseSearchTerm) == true)
                {
                    productsTemp.Add(product);
                }
            }
            return productsTemp.AsQueryable();
            
        }
        

        public static string ConvertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
