
using Model;
using System.Globalization;
using static System.Net.WebRequestMethods;


namespace Web_Client.Services
{
    public class SanphamService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Sanphams"; 


        public async Task<Sanpham_Model> GetProduct(string id)
        {
            return await Http.GetFromJsonAsync<Sanpham_Model>(urldefault + "/" + id);
        }
        public async Task<List<Sanpham_Model>> GetAllProduct()
        {
            return await Http.GetFromJsonAsync<List<Sanpham_Model>>(urldefault);
        }

        public string FormatVND(int price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return price.ToString("#,###", cul.NumberFormat);
        }

        public string GetDetail(string id)
        {
            return "/Detail/" + id;
        }
    }
}