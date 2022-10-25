using Microsoft.AspNetCore.WebUtilities;
using Model;
using Model.Dto;
using Models.Page;
using System.Text.Json;
using Web_Admin_Client.Data;

namespace Web_Admin_Client.Service
{
    public class KhuyenMaiService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/KhuyenMai";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public async Task<List<KhuyenMaiDtoList>> GetListKhuyenMai()
        {
            return await Http.GetFromJsonAsync<List<KhuyenMaiDtoList>>(urldefault);
        }
        public async Task<PagingResponse<KhuyenMaiDtoList>> GetListPageKhuyenMai(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                //["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageKhuyenMai", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<KhuyenMaiDtoList>
            {
                Items = JsonSerializer.Deserialize<List<KhuyenMaiDtoList>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }

        public async Task<KhuyenMaiDtoList> GetkhuyenMaiByEdit(int id)
        {
            return await Http.GetFromJsonAsync<KhuyenMaiDtoList>(urldefault + "/" + id);
        }
        public async Task<KhuyenMaiDto> GetByProduct(string id)
        {
            return await Http.GetFromJsonAsync<KhuyenMaiDto>(urldefault + "/getByProduct?id=" + id);
        }
        public async Task<bool> EditKhuyenMai(int id, KhuyenMaiDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateKhuyenMai(KhuyenMaiDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteKhuyenMai(int id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
    }
}
