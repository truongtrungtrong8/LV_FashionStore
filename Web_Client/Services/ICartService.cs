using Model;

namespace Web_Client.Services
{
    public interface ICartService
    {
        Task AddToCart(CartItems item);
        Task<bool> DeleteCart(string id, string id1);
        Task DeleteItem(CartItems item);
        Task EmptyCart();
        Task<List<CartItems>> GetCartItemInUser(string id);
        Task<List<CartItems>> GetCartItems();
        Task<List<CartItems>> GetCartItems(string id);
    }
}
