using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography;

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


        ////////SortBy/////////
        public static IQueryable<Sanpham_Model> Sort(this IQueryable<Sanpham_Model> products, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(e => e.TenSp);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Sanpham_Model).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(e => e.TenSp);

            return products.OrderBy(orderQuery);
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
