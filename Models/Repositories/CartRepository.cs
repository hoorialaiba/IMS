using IMSIdentity.Data;
using IMSIdentity.Models;
using IMSIdentity.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;   // For ClaimTypes
using Microsoft.AspNetCore.Mvc;  // For ControllerBase / Controller

using System;
using IMSIdentity.Models.Interfaces;
using System.Linq;
using IMSIdentity.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace IMSIdentity.Models.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly MyAppDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CartRepository(MyAppDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Order>> Orders(string userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
        public async Task<List<Order>> Order()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }
        public async Task<List<CartItem>> GetCartItems(string userId)
        {
            return await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<CartAddResult> AddToCart(int productId, string userId)
        {
            //var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);
            var product = await _context.Products
                .FirstOrDefaultAsync(c => c.Id == productId);
            if (product == null) 
            {
                return new CartAddResult
                {
                    Success = false,
                    ErrorMessage = $"No {product.Name} Found."
                };
            }
            else
            {
                if (cartItem != null)
                {
                    int n = cartItem.Quantity;
                    n++;
                    if (product.Quantity <= 0)
                    {
                        return new CartAddResult
                        {
                            Success = false,
                            ErrorMessage = $"Not enough stock for {product.Name}. Only {product.Quantity} left."
                        };
                    }
                    else
                    {
                        cartItem.Quantity++;
                        var existing = _context.Products.FirstOrDefault(c => c.Id == productId);
                        if (existing != null)
                        {
                            existing.Name = product.Name;
                            existing.Brand = product.Brand;
                            existing.Quantity = (product.Quantity - 1);
                            existing.Price = product.Price;
                            existing.Type = product.Type;
                            existing.Expiry = product.Expiry;
                            existing.Description = product.Description;

                            _context.SaveChanges();
                        }
                        await _context.SaveChangesAsync();
                        return new CartAddResult { Success = true };
                    }
                }
                else
                {
                    if (product.Quantity <= 0)
                    {
                        return new CartAddResult
                        {
                            Success = false,
                            ErrorMessage = $"Not enough stock for {product.Name}. Only {product.Quantity} left."
                        };
                    }
                    else
                    {
                        cartItem = new CartItem
                        {
                            ProductId = productId,
                            UserId = userId,
                            Quantity = 1
                        };
                        _context.CartItems.Add(cartItem);
                        var existing = _context.Products.FirstOrDefault(c => c.Id == productId);
                        if (existing != null)
                        {
                            existing.Name = product.Name;
                            existing.Brand = product.Brand;
                            existing.Quantity = (product.Quantity - 1);
                            existing.Price = product.Price;
                            existing.Type = product.Type;
                            existing.Expiry = product.Expiry;
                            existing.Description = product.Description;

                            _context.SaveChanges();
                        }
                        await _context.SaveChangesAsync();
                    }
                    return new CartAddResult { Success = true };
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCart(int productId, string userId)
        {

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);
            var product = await _context.Products
                .FirstOrDefaultAsync(c => c.Id == productId);
            if (cartItem != null)
            {
                var existing = _context.Products.FirstOrDefault(c => c.Id == productId);
                if (existing != null)
                {
                    existing.Name = product.Name;
                    existing.Brand = product.Brand;
                    existing.Quantity = (product.Quantity + cartItem.Quantity);
                    existing.Price = product.Price;
                    existing.Type = product.Type;
                    existing.Expiry = product.Expiry;
                    existing.Description = product.Description;

                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("bakwas" + productId);
                }
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("gggggggg");
            }
        }
        //public async Task RemoveFromCart(int productId, string userId)
        //{
        //    var cartItem = await _context.CartItems
        //        .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);

        //    if (cartItem != null)
        //    {
        //        var product = await _context.Products
        //            .FirstOrDefaultAsync(p => p.Id == productId);

        //        if (product != null)
        //        {
        //            // Restore the stock

        //            product.Name = product.Name;
        //            product.Brand = product.Brand;
        //            //existing.Quantity = (product.Quantity + cartItem.Quantity);
        //            product.Price = product.Price;
        //            product.Type = product.Type;
        //            product.Expiry = product.Expiry;
        //            product.Description = product.Description;
        //            product.Quantity += cartItem.Quantity;

        //            await _context.SaveChangesAsync();
        //        }

        //        _context.CartItems.Remove(cartItem);
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Cart item not found.");
        //    }
        //}


        public async Task ClearCart(string userId)
        {
            var items = _context.CartItems.Where(c => c.UserId == userId);
            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
