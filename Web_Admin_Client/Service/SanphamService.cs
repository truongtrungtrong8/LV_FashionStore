
using Microsoft.AspNetCore.WebUtilities;
using Model;
using Model.DataDB;
using Model.Dto;
using Model.Search;
using Models.Page;
using System.Globalization;
using static System.Net.WebRequestMethods;


namespace Web_Admin_Client.Services
{
    public class SanphamService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Sanphams"; 


        public async Task<Sanpham_Model> GetProduct(string id)
        {
            return await Http.GetFromJsonAsync<Sanpham_Model>(urldefault + "/" + id);
        }
        public async Task<List<Sanpham_Model>> GetAllProduct()
        {
            return await Http.GetFromJsonAsync<List<Sanpham_Model>>(urldefault);
        }

        public string FormatVND(int price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return price.ToString("#,###", cul.NumberFormat);
        }

        public string GetDetail(string id)
        {
            return "/Detail/" + id;
        }

        public async Task<bool> EditSanpham(string id, SanphamEdit request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }

        public async Task<PagedList<Sanpham_Model>> GetListPageSp(SanphamSearch spSearch)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = spSearch.PageNumber.ToString()
            };

            if (!string.IsNullOrEmpty(spSearch.MaSp))
                queryStringParam.Add("maMa", spSearch.MaSp);
            

            string url = QueryHelpers.AddQueryString(urldefault, queryStringParam);
            var request = await Http.GetFromJsonAsync<PagedList<Sanpham_Model>>(url);
            return request;
        }

        public async Task<bool> CreateSanpham(SanphamEdit request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
    }
}