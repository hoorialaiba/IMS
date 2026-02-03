using IMSIdentity.Models;

namespace IMSIdentity.Models.Interfaces
{
    public interface ICartRepository
    {
        Task<List<Order>> Orders(string userId);
        Task<List<Order>> Order();
        Task<List<CartItem>> GetCartItems(string userId);
        Task<CartAddResult> AddToCart(int productId, string userId);
        Task RemoveFromCart(int productId, string userId);
        Task ClearCart(string userId);
    }
}
