using Model;
using Model.DataDB;

namespace Web_Client.Services
{
    public class HinhAnhService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Hinhanhs";


        public async Task<Hinhanh> GetHA(string id)
        {
            return await Http.GetFromJsonAsync<Hinhanh>(urldefault + "/" + id);
        }
        public async Task<List<Hinhanh>> GetAllHA()
        {
            try
            {
                return await Http.GetFromJsonAsync<List<Hinhanh>>(urldefault);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return await Http.GetFromJsonAsync<List<Hinhanh>>(urldefault);
        }
    }
}
