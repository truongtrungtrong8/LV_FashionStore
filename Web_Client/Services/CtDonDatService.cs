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
        public async Task<CtDdh> GetCTDDH(string id)
        {
            return await Http.GetFromJsonAsync<CtDdh>(urldefault + "/" + id);
        }
        public async Task<CtDonDatDto> GetByDanhGia(string id, string id1, int id2)
        {
            return await Http.GetFromJsonAsync<CtDonDatDto>(urldefault + "/getByDanhGia?id=" + id + "&id1=" + id1 + "&id2=" + id2);
        }
        public async Task<List<CtddhDtoList>> GetListByKh(string id)
        {
            return await Http.GetFromJsonAsync<List<CtddhDtoList>>(urldefault + "/getListByKh?id=" + id);
        }
        //https://localhost:7118/api/CtDdhs/id?id=DDH3&id1=SP06
        public async Task<bool> DeleteDDH(string id,string id1, int id2)
        {
            var result = await Http.DeleteAsync(urldefault + "/id?id=" + id + "&id1=" + id1 + "&id2=" + id2);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> EditCtDDH(string id, string id1, int id2, CtDonDatDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id + "?id1=" + id1 + "&id2=" + id2, request);
            return result.IsSuccessStatusCode;
        }
    }
}
