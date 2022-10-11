using Microsoft.AspNetCore.WebUtilities;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using System.Globalization;
using System.Text.Json;
using Web_Admin_Client.Data;
using static System.Net.WebRequestMethods;

namespace Web_Admin_Client.Service
{
    public class NhanvienService
    {
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Nhanviens";


        public async Task<List<Nhanvien>> GetCountNhanvien()
        {
            return await Http.GetFromJsonAsync<List<Nhanvien>>(urldefault + "/countnhanvien");
        }
        

        public async Task<bool> DeleteNhanvien(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
        public async Task<NhanvienDto> GetNhanvien(string id)
        {
            return await Http.GetFromJsonAsync<NhanvienDto>(urldefault + "/" + id);
        }
        public async Task<NhanvienDto> GetNhanviens()
        {
            return await Http.GetFromJsonAsync<NhanvienDto>(urldefault);
        }
        public async Task<bool> EditNhanvien(string id, NhanvienDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateNhanvien(NhanvienDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
       
        public async Task<PagingResponse<NhanvienDto>> GetListPageNhanvien(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                //["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageNhanvien", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<NhanvienDto>
            {
                Items = JsonSerializer.Deserialize<List<NhanvienDto>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }
        public string FormatVND(int price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return price.ToString("#,###", cul.NumberFormat);
        }
    }
}
