using Model;

namespace Web_Client.Services
{
    public interface ICartService
    {
        Task AddToCart(CartItems item);
        Task DeleteItem(CartItems item);
        Task EmptyCart();
        Task<List<CartItems>> GetCartItems();
    }
}
