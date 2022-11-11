using Microsoft.AspNetCore.WebUtilities;
using Model;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using System.Text.Json;
using Web_Admin_Client.Data;

namespace Web_Admin_Client.Service
{
    public class KhachHangService
    {
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Khachhangs";
        public async Task<List<Khachhang>> GetListKhachhang()
        {
            return await Http.GetFromJsonAsync<List<Khachhang>>(urldefault);
        }
        public async Task<PagingResponse<Khachhang>> GetListPageKhachhang(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                ["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageKhachhang", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Khachhang>
            {
                Items = JsonSerializer.Deserialize<List<Khachhang>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }
        public async Task<Khachhang> GetKhachhangById(string id)
        {
            return await Http.GetFromJsonAsync<Khachhang>(urldefault + "/" + id);
        }

        public async Task<bool> DeleteKhachhang(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
    }
}
