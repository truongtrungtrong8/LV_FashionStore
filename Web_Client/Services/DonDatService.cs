using Model.DataDB;
using Model.Dto;

namespace Web_Client.Services
{
    public class DonDatService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/DonDatHangs";

        public async Task<bool> CreateDonDat(DonDatDto request)
        {
            var result = await Http.PostAsJsonAsync(urldefault, request);
            return result.IsSuccessStatusCode;
        }
        public async Task<List<DonDatDto>> GetListByKH(string id)
        {
            return await Http.GetFromJsonAsync<List<DonDatDto>>(urldefault + "/getListByKh?id=" + id);
        }
        public async Task<Dondathang> GetDonDatByDD(string id)
        {
            return await Http.GetFromJsonAsync<Dondathang>(urldefault + "/" +id);
        }
        public async Task<List<DonDatDto>> GetCountDonDat()
        {
            return await Http.GetFromJsonAsync<List<DonDatDto>>(urldefault + "/countDonDat");
        }
        public async Task<List<Dondathang>> GetListAll()
        {
            return await Http.GetFromJsonAsync<List<Dondathang>>(urldefault);
        }
        public async Task<bool> Delete_DD(string id)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id);
            return result.IsSuccessStatusCode;
        }
        public async Task<bool> EditDDH(string id, DonDatDto request)
        {
            var result = await Http.PutAsJsonAsync(urldefault + "/" + id, request);
            return result.IsSuccessStatusCode;
        }

    }
}
