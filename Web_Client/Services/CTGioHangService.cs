using Model.DataDB;
using Model;

namespace Web_Client.Services
{
    public class CTGioHangService
    {
        HttpClient Http = new HttpClient();
        string baseUrl = "https://localhost:7118/api/CtGhs";

        public async Task<List<CtGh>> GetList()
        {
            return await Http.GetFromJsonAsync<List<CtGh>>(baseUrl);
        }

        public async Task<bool> Create(CTGioHangDto request)
        {
            var result = await Http.PostAsJsonAsync(baseUrl, request);
            return result.IsSuccessStatusCode;
        }

    }
}
