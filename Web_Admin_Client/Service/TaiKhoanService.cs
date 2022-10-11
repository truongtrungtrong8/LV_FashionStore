using Microsoft.AspNetCore.WebUtilities;
using Model;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using System.Security.Principal;
using System.Text.Json;
using Web_Admin_Client.Data;

namespace Web_Admin_Client.Service
{
    public class TaiKhoanService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/TaiKhoans";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<List<Taikhoan>> GetListTaikhoan()
        {
            return await Http.GetFromJsonAsync<List<Taikhoan>>(urldefault + "/gettaikhoan");
        }

        public async Task<Taikhoan> GetTaiKhoans()
        {
            return await Http.GetFromJsonAsync<Taikhoan>(urldefault);
        }
        public async Task<TaikhoanDto> GetTaikhoan(string id)
        {
            return await Http.GetFromJsonAsync<TaikhoanDto>(urldefault + "/" + id);
        }
        public async Task<Taikhoan> GetTaiKhoan(string id, string pass)
        {
            return await Http.GetFromJsonAsync<Taikhoan>(urldefault + "/" + id + "/" + pass);
        }

        public async Task<Taikhoan> CheckTaiKhoan(string id)
        {

            return await Http.GetFromJsonAsync<Taikhoan>(urldefault + "/" + id);
            
        }
        public async Task<Taikhoan> AddATaiKhoan(Taikhoan acc)
        {
            acc.Quyensd = "user";
            var response = await Http.PostAsJsonAsync(urldefault + "/", acc);
            return await response.Content.ReadFromJsonAsync<Taikhoan>();
        }

        public async Task<TaikhoanDto> GetTaiKhoanDto()
        {
            return await Http.GetFromJsonAsync<TaikhoanDto>(urldefault);
        }
        public async Task<bool> EditTaikhoan(string id, TaikhoanDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateTaikhoan(TaikhoanDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault + "/page", request);
            return result.IsSuccessStatusCode;
        }


        public async Task<PagingResponse<TaikhoanDto>> GetListPageTaikhoan(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                //["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageTaikhoan", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<TaikhoanDto>
            {
                Items = JsonSerializer.Deserialize<List<TaikhoanDto>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }

        public async Task<bool> DeleteTaikhoan(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
    }
}
