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
        public async Task<DoanhThuNam[]> GetDoanhThuNam(int nam)
        {
            return await Http.GetFromJsonAsync<DoanhThuNam[]>(urldefault + "/getByYear?nam=" + nam);
        }
        public async Task<DoanhThuQuy[]> GetDoanhThuQuy(int nam)
        {
            return await Http.GetFromJsonAsync<DoanhThuQuy[]>(urldefault + "/getByQuy?nam=" + nam);
        }
        public async Task<DoanhThuThang> GetDoanhThuThangByID(int id)
        {
            return await Http.GetFromJsonAsync<DoanhThuThang>(urldefault + "/getMonthByID?id=" + id);
        }
        public async Task<DoanhThuNam> GetDoanhThuNamByID(string id,int id1)
        {
            return await Http.GetFromJsonAsync<DoanhThuNam>(urldefault + "/getYearByID?id=" + id + "&id1=" + id1);
        }
        public async Task<DoanhThuQuy> GetDoanhThuQuyByID(string id, int id1)
        {
            return await Http.GetFromJsonAsync<DoanhThuQuy>(urldefault + "/getQuyByID?id=" + id + "&id1=" + id1);
        }
        public async Task<bool> EditByMonth(int id, DoanhThuThang request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/putByMonth?id=" + id, request);
            return result.IsSuccessStatusCode;
        }
        //https://localhost:7118/api/DoanhThus/putByYear?id=Th%C3%A1ng%201&id1=2021&id3=1
        public async Task<bool> EditByYear(string id, int id1, int id2,DoanhThuNam request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/putByYear?id=" + id + "&id1=" + id1 + "&id2=" + id2, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> EditByQuy(int id, string id1, int id2 ,DoanhThuQuy request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/putByQuy?id=" + id + "&id1=" + id1 + "&id2=" + id2, request);
            return result.IsSuccessStatusCode;
        }
    }
}
