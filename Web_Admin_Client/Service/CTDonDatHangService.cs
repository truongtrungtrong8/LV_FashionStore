using Model.DataDB;
using Model.Dto;
using System.Globalization;

namespace Web_Admin_Client.Service
{
    public class CTDonDatHangService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/CtDdhs";
        public async Task<List<CtDdh>> GetCtDDH()
        {
            return await Http.GetFromJsonAsync<List<CtDdh>>(urldefault);
        }
        public string FormatVND(int price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return price.ToString("#,###", cul.NumberFormat);
        }
    }
}
