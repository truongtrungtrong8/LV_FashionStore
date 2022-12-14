using Model.DataDB;
using Model.Dto;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Web_Client.Services
{
    public class TaiKhoanService
    {
        HttpClient Http = new HttpClient();
        //https://localhost:7118/api/Taikhoans/GetLogin?id=0866822179&pwd=123456
        string urldefault = "https://localhost:7118/api/Taikhoans";
        public async Task<Taikhoan> GetTaiKhoan(string id, string pass)
        {
            return await Http.GetFromJsonAsync<Taikhoan>(urldefault + "/GetLogin?id=" + id + "&pwd=" + pass);
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
        public async Task<bool> EditTaikhoan(string id, TaikhoanDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> Delete_TK(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
    }
}
