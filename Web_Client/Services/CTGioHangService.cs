using Model.DataDB;
using Model;
using DocumentFormat.OpenXml.Office2010.Excel;


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
        ///GetCart
        public async Task<List<CartItems>> GetCartAllInUser(string id)
        {
            return await Http.GetFromJsonAsync<List<CartItems>>(baseUrl + "/" + id);
        }
        public async Task<bool> Create(CTGioHangDto request)
        {
            var result = await Http.PostAsJsonAsync(baseUrl, request);
            return result.IsSuccessStatusCode;
        }
        ///https://localhost:7118/api/CtGhs/GetCTGiohang?id=1
        //public async Task<CTGioHangDto> GetCtGiohang(string id)
        //{
        //    return await Http.GetFromJsonAsync<CTGioHangDto>(baseUrl + "/GetCTGiohang?id=" + id);
        //}
        //public async Task<CTGioHangDto> GetCtGiohangSP(string id)
        //{
        //    return await Http.GetFromJsonAsync<CTGioHangDto>(baseUrl + "/GetCTGiohangSanpham?id=" + id);
        //}
        public async Task<bool> Edit(string id,string id1, CTGioHangDto request)
        {
            var result = await Http.PutAsJsonAsync(baseUrl + "/" + id + "?id1=" + id1, request);
            return result.IsSuccessStatusCode;
        }
        ///https://localhost:7118/api/CtGhs/GetCTGiohang?id=Sp03&id1=GH0866822122
        public async Task<CTGioHangDto> GetID(string id, string id1)
        {
            return await Http.GetFromJsonAsync<CTGioHangDto>(baseUrl + "/GetCTGiohang?id=" + id + "&id1=" + id1);

        }
        //https://localhost:7118/api/CtGhs/SP01?id1=GH0866822122
        public async Task<bool> DeleteCart(string id,string id1)
        {
            var result = await Http.DeleteAsync(baseUrl + "/" + id + "?id1=" + id1);
            return result.IsSuccessStatusCode;
        }
    }
}
