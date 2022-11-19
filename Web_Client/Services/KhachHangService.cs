using Model;
using Model.DataDB;
using Model.Dto;

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
        public async Task<List<Khachhang>> GetListKH()
        {
            var kh = await Http.GetFromJsonAsync<List<Khachhang>>(urldefault);
            return kh;
        }
        public async Task<Khachhang> GetKhachHang(string id)
        {
            
            var result = await Http.GetFromJsonAsync<Khachhang>(urldefault + "/" + id);
            
            return result;
        }
        public async Task<KhachHangDto> GetKHID(string id)
        {
            var result = await Http.GetFromJsonAsync<KhachHangDto>(urldefault + "/getKhID?id=" + id);
            return result;
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
        public async Task<bool> EditKhachhang(string id, KhachHangDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
    }
}
