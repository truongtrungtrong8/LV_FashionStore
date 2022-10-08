using Model.Dto;

namespace Web_Client.Services
{
    public class CtDonDatService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/CtDdhs";

        public async Task<bool> CreateCtdonDat(CtDonDatDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
    }
}
