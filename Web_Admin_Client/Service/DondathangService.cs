using Model.DataDB;
using Model.Dto;
using System.Globalization;

namespace Web_Admin_Client.Service
{
    public class DondathangService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/DonDatHangs";
        public async Task<List<DonDatDto>> GetListAll()
        {
            return await Http.GetFromJsonAsync<List<DonDatDto>>(urldefault + "/countDonDat");
        }
        public async Task<DonDatDto[]> GetList()
        {
            return await Http.GetFromJsonAsync<DonDatDto[]>(urldefault + "/countDonDat");
        }
        public string FormatVND(double price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return price.ToString("#,###", cul.NumberFormat);
        }
    }
}

