
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.WebUtilities;
using Model;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using System.Globalization;
using System.Net;
using System.Text.Json;
using Web_Admin_Client.Data;
using static System.Net.WebRequestMethods;


namespace Web_Admin_Client.Service
{
    public class SanphamService
    {
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Sanphams"; 


        public async Task<Sanpham_Model> GetProduct(string id)
        {
            return await Http.GetFromJsonAsync<Sanpham_Model>(urldefault + "/" + id);
        }
        public async Task<SanphamEdit> GetProductByExcel(string id)
        {
            return await Http.GetFromJsonAsync<SanphamEdit>(urldefault + "/getExcel?id=" + id);
        }
        public async Task<List<Sanpham_Model>> GetAllProducts()
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

        public async Task<PagingResponse<Sanpham_Model>> GetListPageSp(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                ["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm,
                ["orderBy"] = paging.OrderBy
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/page", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Sanpham_Model>
            {
                Items = JsonSerializer.Deserialize<List<Sanpham_Model>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;
           
        }

        public async Task<bool> CreateSanpham(SanphamEdit request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }

        public async Task<List<Sanpham>> GetAllProductQuantily()
        {
            return await Http.GetFromJsonAsync<List<Sanpham>>(urldefault + "/products");
        }
        public async Task<bool> DeleteSanpham(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
    }
}