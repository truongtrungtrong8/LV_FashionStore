using Microsoft.AspNetCore.Http;
using Model.DataDB;
using Model.Dto;
using static System.Net.WebRequestMethods;

namespace Web_Admin_Client.Service
{
    public class HinhanhService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Hinhanhs";
        
    }
}
