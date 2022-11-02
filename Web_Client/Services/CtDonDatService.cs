using Model.DataDB;
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
        public async Task<List<CtddhDtoList>> GetList(string id)
        {
            return await Http.GetFromJsonAsync<List<CtddhDtoList>>(urldefault + "/getList?id=" + id);
        }
        //https://localhost:7118/api/CtDdhs/id?id=DDH3&id1=SP06
        public async Task<bool> DeleteDDH(string id,string id1)
        {
            var result = await Http.DeleteAsync(urldefault + "/id?id=" + id + "&id1=" + id1);
            return result.IsSuccessStatusCode;
        }

    }
}
