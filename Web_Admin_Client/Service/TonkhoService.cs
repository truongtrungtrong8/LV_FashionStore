using Microsoft.AspNetCore.WebUtilities;
using Model.Dto;
using Models.Page;
using System.Globalization;
using System.Text.Json;
using Web_Admin_Client.Data;

namespace Web_Admin_Client.Service
{
    public class TonkhoService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Tonkhos";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<List<ThongKeDto>> GetListTonkho()
        {
            return await Http.GetFromJsonAsync<List<ThongKeDto>>(urldefault + "/getThongke");
        }
        public async Task<PagingResponse<TonkhoDtoList>> GetListPageTonkho(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                //["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageTonkho", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<TonkhoDtoList>
            { 
                Items = JsonSerializer.Deserialize<List<TonkhoDtoList>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }
        public string FormatVND(int price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return price.ToString("#,###", cul.NumberFormat);
        }
        public async Task<bool> CreateTonkho(TonkhoDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<TonkhoDto> GetTonkho(string id)
        {
            return await Http.GetFromJsonAsync<TonkhoDto>(urldefault + "/" + id);
        }
        //https://localhost:7118/api/Tonkhos/SP17?id1=CH01
        public async Task<bool> DeleteTonkho(string id,string id1)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id + "?id1=" + id1);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> EditTonkho(string id, string id1,TonkhoDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id + "?id1=" + id1, request);
            return result.IsSuccessStatusCode;
        }
    }
}
