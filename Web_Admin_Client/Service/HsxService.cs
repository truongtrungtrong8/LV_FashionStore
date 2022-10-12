using Microsoft.AspNetCore.WebUtilities;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using System.Text.Json;
using Web_Admin_Client.Data;

namespace Web_Admin_Client.Service
{
    public class HsxService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Hxs";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<List<HangsxDto>> GetListHsx()
        {
            return await Http.GetFromJsonAsync<List<HangsxDto>>(urldefault);
        }
        public async Task<List<Hx>> GetCountHsx()
        {
            return await Http.GetFromJsonAsync<List<Hx>>(urldefault + "/count");
        }

        public async Task<HangsxDto> GetHsx(string id)
        {
            return await Http.GetFromJsonAsync<HangsxDto>(urldefault + "/" + id);
        }
        public async Task<bool> EditHsx(string id, HangsxDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateHsx(HangsxDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteHsx(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }

        public async Task<PagingResponse<HangsxDto>> GetListPageLoaiSp(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                //["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageHsx", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<HangsxDto>
            {
                Items = JsonSerializer.Deserialize<List<HangsxDto>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }
    }
}
