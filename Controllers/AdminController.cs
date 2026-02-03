using IMSIdentity.Hubs;
using IMSIdentity.Models;
using IMSIdentity.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace IMSIdentity.Controllers
{
    [Authorize(Policy = "RequireAdmin")]
    public class AdminController : Controller
    {
        private readonly MyAppDBContext _context;
        private readonly ICartRepository _cartService;
        private readonly IProductRepository _pr;
        private readonly IHubContext<AlertHub> _hubContext;
        private readonly IAlertRepository _alertRepo;

        public AdminController(IProductRepository productRepo, IHubContext<AlertHub> hubContext, IAlertRepository alertRepo, ICartRepository cartService, MyAppDBContext context)
        {
            _context = context;
            _cartService = cartService;
            _pr = productRepo;
            _hubContext = hubContext;
            _alertRepo = alertRepo;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(string name, string brand, int quantity, decimal price, string type, string expiry, string barcode, string description)
        {
            Product product = new Product();
            product.Name = name;
            product.Brand = brand;
            product.Quantity = quantity;
            product.Price = price;
            product.Type = type;
            product.Expiry = expiry;
            product.Barcode = barcode;
            product.Description = description;

            _pr.Add(product);
            await _alertRepo.CreateAndBroadcastAsync("Product Added", "Admin added a new product", "bi-plus-circle");
            return RedirectToAction("Dash");
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmEdit(string name, string brand, int quantity, decimal price, string type, string expiry, string barcode, string description) 
        {
            Product product = new Product();
            product.Name = name;
            product.Brand = brand;
            product.Quantity = quantity;
            product.Price = price;
            product.Type = type;
            product.Expiry = expiry;
            product.Barcode = barcode;
            product.Description = description;
            _pr.Update(product);
            await _alertRepo.CreateAndBroadcastAsync("Product Edited", $"Admin edited a product: {product.Name}", "bi bi-pencil-square text-danger");
            return RedirectToAction("Dash");
        }
        [HttpGet]
        public IActionResult Edit(string barcode)
        {
            var product = _pr.GetById(barcode);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Product()
        {
            List<Product> list = new List<Product>();
            list = _pr.GetAll();
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(string barcode)
        {
            var product = _pr.GetById(barcode);
            string name = product.Name;
            _pr.Delete(barcode);
            await _alertRepo.CreateAndBroadcastAsync("Product Deleted", $"Admin Deleted a product: {name}", "bi bi-trash text-danger");
            return RedirectToAction("Dash");
        }
        public async Task<IActionResult> Order()
        {
            var orders = await _cartService.Order(); // fetch user-specific orders
            return View(orders); // pass to view
        }

        [HttpGet]
        public IActionResult Delete(string barcode)
        {
            var product = _pr.GetById(barcode);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult Dash()
        {
            List<Product> list = new List<Product>();
            list = _pr.GetAll();
            return View(list);
        }
    }
}
