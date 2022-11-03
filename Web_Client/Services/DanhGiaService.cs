using Model.Dto;

namespace Web_Client.Services
{
    public class DanhGiaService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/DanhGias";
        public async Task<List<DanhGiaDto>> GetListDanhGiaByPro(string id)
        {
            return await Http.GetFromJsonAsync<List<DanhGiaDto>>(urldefault + "/getListByProduct?id=" + id);
        }
        public async Task<bool> EditReview(string id, DanhGiaDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateReview(DanhGiaDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteReview(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
    }
}
