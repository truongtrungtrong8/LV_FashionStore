using Model.DataDB;

namespace Web_Admin_Client.Service
{
    public class LoaiSpService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/LoaiSps";

        public async Task<List<LoaiSp>> GetListLoaiSp()
        {
            return await Http.GetFromJsonAsync<List<LoaiSp>>(urldefault);
        }

        public async Task<LoaiSp> GetDetailLoaiSp(string id)
        {
            return await Http.GetFromJsonAsync<LoaiSp>(urldefault + "/" + id);
        }
    }
}
