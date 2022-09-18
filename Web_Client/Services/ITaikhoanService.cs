using Model.DataDB;

namespace Web_Client.Services
{
    public interface ITaikhoanService
    {
        Task<Taikhoan> AddATaiKhoan(Taikhoan acc);
        Task<Taikhoan> CheckTaiKhoan(string id);
        Task<Taikhoan> GetTaiKhoan(string id, string pass);
    }
}
