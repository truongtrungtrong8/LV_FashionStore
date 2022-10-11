using Model.DataDB;
using System.Text.Json;

namespace Web_Admin_Client.Service
{
    public class CuahangService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Cuahangs";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<List<Cuahang>> GetListCuahang()
        {
            return await Http.GetFromJsonAsync<List<Cuahang>>(urldefault);
        }
    }
}
