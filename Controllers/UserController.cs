using System.Security.Claims;
using IMSIdentity.Data;
using IMSIdentity.Models;
using IMSIdentity.Models.Interfaces;
using IMSIdentity.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using static NuGet.Packaging.PackagingConstants;

namespace IMSIdentity.Controllers
{
    [Authorize(Policy = "RequireUser")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICartRepository _cartService;
        private readonly MyAppDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserController(ICartRepository cartService, MyAppDBContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _cartService = cartService;
            _context = context;

            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Orders()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _cartService.Orders(userId); // fetch user-specific orders
            return View(orders); // pass to view
        }

        
        public async Task<IActionResult> Cart()
        {
            var userId = _userManager.GetUserId(User);
            var items = await _cartService.GetCartItems(userId);
            return View("Cart", items);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            //var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!User.Identity.IsAuthenticated)
            {
                Console.WriteLine("User is NOT authenticated");
            }

            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                Console.WriteLine("Authenticated, but no NameIdentifier claim found.");
            }
            var result = await _cartService.AddToCart(id, userId);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return RedirectToAction("Cart"); // Or return View(...);
            }
            //await _cartService.AddToCart(id, userId);
            return RedirectToAction("Cart");
        }

        //[HttpGet]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = _userManager.GetUserId(User); // This works well
            await _cartService.RemoveFromCart(id, userId);
            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> Checkout()
        {
            var userId = _userManager.GetUserId(User);

            var items = await _cartService.GetCartItems(userId);
            if (!items.Any())
            {
                ModelState.AddModelError("", "Your cart is empty.");
                return RedirectToAction("Cart");
            }

            var order = new Order
            {
                OrderItems = items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Product.Price
                }).ToList(),
                UserId = userId,
                TotalAmount = items.Sum(i => i.Product.Price * i.Quantity),
                OrderDate = DateTime.UtcNow
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            await _cartService.ClearCart(userId);

            return RedirectToAction("Orders");
        }

        public IActionResult Udash()
        {
            return View();
        }
    }
}
