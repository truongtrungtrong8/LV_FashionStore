using Microsoft.AspNetCore.WebUtilities;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using System.Text.Json;
using Web_Admin_Client.Data;

namespace Web_Admin_Client.Service
{
    public class LoaiSpService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/LoaiSps";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<List<LoaiDto>> GetListLoaiSp()
        {
            return await Http.GetFromJsonAsync<List<LoaiDto>>(urldefault);
        }
        public async Task<List<LoaiSp>> GetCountLoai()
        {
            return await Http.GetFromJsonAsync<List<LoaiSp>>(urldefault + "/count");
        }

        public async Task<LoaiDto> GetLoaiSp(string id)
        {
            return await Http.GetFromJsonAsync<LoaiDto>(urldefault + "/" + id);
        }
        public async Task<bool> EditLoai(string id, LoaiDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateLoai(LoaiDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteLoai(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }

        public async Task<PagingResponse<LoaiDto>> GetListPageLoaiSp(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                //["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageLoaiSp", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<LoaiDto>
            {
                Items = JsonSerializer.Deserialize<List<LoaiDto>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }
    }
}
