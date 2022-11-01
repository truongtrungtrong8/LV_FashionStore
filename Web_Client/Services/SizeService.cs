using Model.DataDB;
using Model.Dto;

namespace Web_Client.Services
{
    public class SizeService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Size";
        public async Task<List<Size>> GetListSize()
        {
            return await Http.GetFromJsonAsync<List<Size>>(urldefault);
        }
    }
}
