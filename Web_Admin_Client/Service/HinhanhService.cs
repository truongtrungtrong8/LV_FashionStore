using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Model;
using Model.DataDB;
using Model.Dto;
using Models.Page;
using System.Text.Json;
using Web_Admin_Client.Data;
using static System.Net.WebRequestMethods;

namespace Web_Admin_Client.Service
{
    public class HinhanhService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Hinhanhs";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };


        public async Task<List<Images_Model>> GetAllImages()
        {
            return await Http.GetFromJsonAsync<List<Images_Model>>(urldefault);
        }
        public async Task<List<Images_Model>> GetImageByImage(string id)
        {
            return await Http.GetFromJsonAsync<List<Images_Model>>(urldefault + "/getImageByImage?id=" + id);
        }

        public async Task<bool> AddImage(ImageDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<Images_Model> GetProductByImage(string id)
        {
            return await Http.GetFromJsonAsync<Images_Model>(urldefault + "/getImage?id=" + id);
        }
        public async Task<ImageDto> GetImageByID(string id)
        {
            return await Http.GetFromJsonAsync<ImageDto>(urldefault + "/getImageBySP?id=" + id);
        }

        public async Task<PagingResponse<Images_Model>> GetListPageImage(PagingParameters paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                //["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageImage", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Images_Model>
            {
                Items = JsonSerializer.Deserialize<List<Images_Model>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }

        public async Task<bool> DeleteHinhanh(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> EditImages(int id, ImageDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
    }
}
