using Model.DataDB;

namespace Web_Client.Services
{
    public class MauService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Mau";
        public async Task<List<Mau>> GetListMau()
        {
            return await Http.GetFromJsonAsync<List<Mau>>(urldefault);
        }
    }
}
