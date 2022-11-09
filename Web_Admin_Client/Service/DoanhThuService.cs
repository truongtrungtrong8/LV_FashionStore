using Model;
using Model.DataDB;
using Model.Dto;

namespace Web_Admin_Client.Service
{
    public class DoanhThuService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/DoanhThus";

        public async Task<DoanhThuThang[]> GetDoanhThuThang()
        {
            return await Http.GetFromJsonAsync<DoanhThuThang[]>(urldefault + "/getByMonth");
        }
        public async Task<DoanhThuNam[]> GetDoanhThuNam()
        {
            return await Http.GetFromJsonAsync<DoanhThuNam[]>(urldefault + "/getByYear");
        }
        public async Task<DoanhThuQuy[]> GetDoanhThuQuy()
        {
            return await Http.GetFromJsonAsync<DoanhThuQuy[]>(urldefault + "/getByQuy");
        }
        public async Task<bool> CreateByMonth(DoanhThuThang request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateByYear(DoanhThuNam request)
        {
            var result = await Http.PostAsJsonAsync(urldefault + "/postByYear", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateByQuy(DoanhThuQuy request)
        {
            var result = await Http.PostAsJsonAsync(urldefault + "/postByQuy", request);
            return result.IsSuccessStatusCode;
        }
        public async Task<DoanhThuThang> GetDoanhThuThangByID(int id)
        {
            return await Http.GetFromJsonAsync<DoanhThuThang>(urldefault + "/getMonthByID?id=" + id);
        }
        public async Task<DoanhThuNam> GetDoanhThuNamByID(int id)
        {
            return await Http.GetFromJsonAsync<DoanhThuNam>(urldefault + "/getYearByID?id=" + id);
        }
        public async Task<DoanhThuQuy> GetDoanhThuQuyByID(int id)
        {
            return await Http.GetFromJsonAsync<DoanhThuQuy>(urldefault + "/getQuyByID?id=" + id);
        }
        public async Task<bool> EditByMonth(int id, DoanhThuThang request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/putByMonth?id=" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> EditByYear(int id, DoanhThuNam request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/putByYear?id=" + id, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> EditByQuy(int id, DoanhThuQuy request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/putByQuy?id=" + id, request);
            return result.IsSuccessStatusCode;
        }
    }
}
