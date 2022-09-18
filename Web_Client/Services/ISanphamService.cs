using Model;

namespace Web_Client.Services
{
    public interface ISanphamService
    {
        string FormatVND(int price);
        Task<List<Sanpham_Model>> GetAllProduct();
        string GetDetail(string id);
        Task<Sanpham_Model> GetProduct(string id);
    }
}
