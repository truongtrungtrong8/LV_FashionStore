using Model;
using Model.DataDB;

namespace Web_Client.Services
{
    public class KhachHangService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Khachhangs";

        public async Task<Khachhang> AddAKhachHang(Khachhang khachhang)
        {
            var response = await Http.PostAsJsonAsync(urldefault + "/", khachhang);
            return await response.Content.ReadFromJsonAsync<Khachhang>();
        }
        public async Task<Khachhang> GetKhachHang(string id)
        {
            
            return await Http.GetFromJsonAsync<Khachhang>(urldefault + "/" + id);
        }
        public async Task<Khachhang> GetDetail(string id)
        {
            return await Http.GetFromJsonAsync<Khachhang>(urldefault + "/" + id);
        }
        public async Task<List<Khachhang>> GetKH_Mail(string id)
        {
            var kh = await Http.GetFromJsonAsync<List<Khachhang>>(urldefault + "/" + id);
            return kh;

        }
    }
}
