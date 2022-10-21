using Model.DataDB;
using Model.Dto;

namespace Web_Client.Services
{
    public class TonkhoService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Tonkhos";

        public async Task<List<TonkhoDto>> GetListTonkho()
        {
            return await Http.GetFromJsonAsync<List<TonkhoDto>>(urldefault);
        }
        public async Task<TonkhoDto> GetTonkho(string id)
        {
            return await Http.GetFromJsonAsync<TonkhoDto>(urldefault + "/" + id);
        }
        //https://localhost:7118/api/Tonkhos/SP01?id2=CH01
        public async Task<bool> EditTonkho(string id, string id2, TonkhoDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id + "?id2=" + id2, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> CreateTonkho(TonkhoDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
    }
}
