using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Blazored.Toast.Services;
using DocumentFormat.OpenXml.Spreadsheet;
using Model;
using Model.DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Client.Pages.Cart;
using static System.Net.WebRequestMethods;

namespace Web_Client.Services
{

    public class CartService: ICartService
    {
        HttpClient Http = new HttpClient();
        string urldefault = "https://localhost:7118/api/CtGhs";
        public event Action OnChange;
        private readonly ILocalStorageService _localStorage;
        private readonly ISessionStorageService _sessionStorage;
        private readonly IToastService _toastService;
        private readonly ISanphamService _productService;
        public CartService(
            ILocalStorageService localStorage,
            ISessionStorageService sessionStorage,
            IToastService toastService,
            ISanphamService productService)
        {
            _localStorage = localStorage;
            _sessionStorage = sessionStorage;
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
                var sameItem = cart.Find(x => x.MaSp == item.MaSp);
                if (sameItem == null)
                {
                    cart.Add(item);
                }
                else
                {
                    sameItem.Sl += item.Sl;
                }

                await _localStorage.SetItemAsync("cart", cart);
                
                OnChange.Invoke();
            }
            catch (Exception ex)
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
        public async Task<List<CartItems>> GetCartItems(string item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            var gh = cart.Where(g => g.MaKh == item).ToList();
            if (gh != null)
            {

                return gh;
            }
            return new List<CartItems>();

        }

        public async Task<List<CartItems>> GetCartItemInUser(string id)
        {
            var cart = await Http.GetFromJsonAsync<List<CartItems>>(urldefault + "/" + id);
            return cart;
            
        }
        public async Task DeleteItem(CartItems item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItems>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.MaSp == item.MaSp);
            
            try
            {
                cart.Remove(cartItem);
                _toastService.ShowSuccess("Mời bạn tiếp tục mua hàng!", "Xóa thành công !" );
                await _localStorage.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }
            catch(Exception ex)
            {

            }
            
        }

        public async Task<bool> DeleteCart(string id, string id1)
        {
            var result = await Http.DeleteAsync(urldefault + "/" + id + "?=" + id1);
            return result.IsSuccessStatusCode;

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
