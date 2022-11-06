using Microsoft.AspNetCore.WebUtilities;
using Model;
using Model.DataDB;
using Model.PageIndex;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Web_Client.Data;
using static System.Net.WebRequestMethods;


namespace Web_Client.Services
{
    public class SanphamService: ISanphamService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/Sanphams";
        JsonSerializerOptions _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public async Task<Sanpham_Model> GetProduct(string id)
        {
            return await Http.GetFromJsonAsync<Sanpham_Model>(urldefault + "/" + id);
        }
        public async Task<List<Sanpham_Model>> GetAllProduct()
        {
            return await Http.GetFromJsonAsync<List<Sanpham_Model>>(urldefault);
        }

        public string FormatVND(double price)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return price.ToString("#,###", cul.NumberFormat);
        }

        public string GetDetail(string id)
        {
            return "/Detail/" + id;
        }

        public async Task<PagingResponse<Sanpham_Model>> GetListPageSp(PagingParametersIndex paging)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = paging.PageNumber.ToString(),
                ["searchTerm"] = paging.SearchTerm == null ? "" : paging.SearchTerm
            };
            var response = await Http.GetAsync(QueryHelpers.AddQueryString(urldefault + "/pageIndex", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<Sanpham_Model>
            {
                Items = JsonSerializer.Deserialize<List<Sanpham_Model>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaDataIndex>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;

        }
        public string DeCodeMd5(string cipher)
        {
            string key = "A!9HHhi%XjjYY4YP2@Nob009X";
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }

        public string EndCodeMd5(string text)
        {
            string key = "A!9HHhi%XjjYY4YP2@Nob009X";
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
}