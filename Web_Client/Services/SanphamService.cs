using Model;
using System.Globalization;


namespace Web_Client.Services
{
    public class SanphamService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Sanphams";


        public async Task<Sanpham_Model> GetHotel(string id)
        {
            return await Http.GetFromJsonAsync<Sanpham_Model>(urldefault + "/" + id);
        }
        public async Task<List<Sanpham_Model>> GetAllHotel()
        {
            return await Http.GetFromJsonAsync<List<Sanpham_Model>>(urldefault);
        }
    }
}