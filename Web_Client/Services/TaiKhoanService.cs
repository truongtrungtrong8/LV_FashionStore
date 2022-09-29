using Model.DataDB;
using System.Security.Principal;

namespace Web_Client.Services
{
    public class TaiKhoanService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/TaiKhoans";
        public async Task<Taikhoan> GetTaiKhoan(string id, string pass)
        {
            return await Http.GetFromJsonAsync<Taikhoan>(urldefault + "/" + id + "/" + pass);
        }

        public async Task<Taikhoan> CheckTaiKhoan(string id)
        {
            return await Http.GetFromJsonAsync<Taikhoan>(urldefault + "/" + id);
        }
        public async Task<Taikhoan> AddATaiKhoan(Taikhoan acc)
        {
            acc.Quyensd = "user";
            var response = await Http.PostAsJsonAsync(urldefault + "/", acc);
            return await response.Content.ReadFromJsonAsync<Taikhoan>();
        }
    }
}
