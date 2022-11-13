using Model.DataDB;
using Model.Dto;
using static System.Net.WebRequestMethods;

namespace Web_Admin_Client.Service
{
    public class QuanLyNVService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/QuanlyNV";
        string urlNV = "https://localhost:7118/api/Nhanviens";
        public async Task<bool> Create_NV(QuanLyNv request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<List<QuanLyNv>> GetList()
        {
            return await Http.GetFromJsonAsync<List<QuanLyNv>>(urldefault);
        }
        public async Task<NhanvienDto> GetNhanvienByTk(string id)
        {
            return await Http.GetFromJsonAsync<NhanvienDto>(urlNV + "/getNhanvienByTk?id=" + id);
        }
    }
}
