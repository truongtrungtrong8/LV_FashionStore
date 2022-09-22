using Model;
using Model.DataDB;

namespace Web_Client.Services
{
    public class GioHangService
    {
        HttpClient Http = new HttpClient();
        string baseUrl = "https://localhost:7118/api/Giohangs";

        public async Task<List<Giohang>> GetList()
        {
            return await Http.GetFromJsonAsync<List<Giohang>>(baseUrl);
        }

        public async Task<Giohang> GetDetail(string id)
        {
            return await Http.GetFromJsonAsync<Giohang>(baseUrl + "/" + id);
        }

        public async Task<bool> Create(GioHangDto request)
        {
            var result = await Http.PostAsJsonAsync(baseUrl, request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Edit(string id, Giohang request)
        {
            var result = await Http.PutAsJsonAsync($"https://localhost:7118/api/Giohangs/{id}", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await Http.DeleteAsync(baseUrl + "/" + id);
            return result.IsSuccessStatusCode;
        }
    }
}
