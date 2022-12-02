using Microsoft.AspNetCore.WebUtilities;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using System.Globalization;
using System.Text.Json;
using Web_Admin_Client.Data;

namespace Web_Admin_Client.Service
{
    public class DondathangService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/DonDatHangs";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public async Task<List<DonDatDto>> GetListAll()
        {
            return await Http.GetFromJsonAsync<List<DonDatDto>>(urldefault + "/countDonDat");
        }
        public async Task<DonDatDto[]> GetList()
        {
            return await Http.GetFromJsonAsync<DonDatDto[]>(urldefault + "/countDonDat");
        }
        public string FormatVND(double price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return price.ToString("#,###", cul.NumberFormat);
        }
        public async Task<PagingResponse<DonDatNewDto>> GetListPage(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                //["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/getKhByDonDat", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<DonDatNewDto>
            {
                Items = JsonSerializer.Deserialize<List<DonDatNewDto>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }
        public async Task<Dondathang> GetDonDatById(string id)
        {
            return await Http.GetFromJsonAsync<Dondathang>(urldefault + "/" + id);
        }
        public async Task<bool> Delete_DD(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> EditDDH(string id, DonDatDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
    }
}

