using Model.DataDB;

namespace Web_Admin_Client.Service
{
    public class HsxService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Hxs";

        public async Task<List<Hx>> GetListHsx()
        {
            return await Http.GetFromJsonAsync<List<Hx>>(urldefault);
        }

        public async Task<Hx> GetDetailHsx(string id)
        {
            return await Http.GetFromJsonAsync<Hx>(urldefault + "/" + id);
        }
    }
}
