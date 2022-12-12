using Model.DataDB;
using Model.Dto;

namespace Web_Client.Services
{
    public class HoaDonService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Hoadons";

        public async Task<List<Hoadon>> GetList()
        {
            return await Http.GetFromJsonAsync<List<Hoadon>>(urldefault);
        }
        public async Task<bool> Create(HoaDonDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
    }
}
