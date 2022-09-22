using Blazored.LocalStorage;
using Blazored.Toast.Services;
using DocumentFormat.OpenXml.Spreadsheet;
using Model;
using Model.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Web_Client.Services
{
    public class CartService: ICartService
    {
        public event Action OnChange;
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;
        private readonly ISanphamService _productService;
        public CartService(
            ILocalStorageService localStorage,
            IToastService toastService,
            ISanphamService productService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
        }
        public async Task AddToCart(CartItems item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
            {
                cart = new List<CartItems>();
            }
            try
            {
            var sameItem = cart.Find(x => x.MaSp == item.MaSp && x.TenSp == item.TenSp);
            if (sameItem == null)
            {
                cart.Add(item);
            }
            else
            {
                sameItem.Sl += item.Sl;
            }
           
                await _localStorage.SetItemAsync("cart", cart);
                _toastService.ShowSuccess("Mời bạn tiếp tục mua hàng!", "Sản phẩm đã cho vào giỏ hàng");
                OnChange.Invoke();
            }
            catch(Exception ex)
            {

            }
           
        }

        public async Task<List<CartItems>> GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
            {
                return new List<CartItems>();
            }
            return cart;
        }
        public async Task DeleteItem(CartItems item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.MaSp == item.MaSp && x.MaGh == item.MaGh);
            
            try
            {
                cart.Remove(cartItem);
                _toastService.ShowSuccess("Mời bạn tiếp tục mua hàng!", "Bạn đã xóa sản phẩm khỏi giỏ hàng" );
                await _localStorage.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
            catch(Exception ex)
            {

            }
            
        }
        public async Task EmptyCart()
        {
            try
            {
                await _localStorage.RemoveItemAsync("cart");
                OnChange.Invoke();
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
