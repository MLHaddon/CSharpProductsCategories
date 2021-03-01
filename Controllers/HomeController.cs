using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Context;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
     
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return RedirectToAction("Products");
        }

        [HttpGet("Products")]
        public IActionResult Products()
        {
            ViewBag.Products = _context.Products
                .ToList();
            return View();
        }

        [HttpPost("Products/CreateProduct")]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Redirect("/");
            }
            else
            {
                return View("Products");
            }
        }
        [HttpGet("Products/{ProductId}/Delete")]
        public IActionResult DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Redirect("/Products");
        }

        [HttpGet("Products/{ProductId}")]
        public IActionResult Product(int ProductId)
        {
            ViewBag.Product = _context.Products
                .Include(p => p.ProductCategories)
                    .ThenInclude(c => c.Category)
                .FirstOrDefault(p => p.ProductId == ProductId);

            ViewBag.NotCategories = _context.Categories
                .Include(c => c.CategoryProducts)
                .Where(c => c.CategoryProducts.All(cp => cp.ProductId != ProductId))
                .ToList();
            return View();
        }

        [HttpPost("Product/{ProductId}/AddCategory")]
        public IActionResult AddCategory(Association association)
        {
            if (ModelState.IsValid)
            {
                _context.Associations.Add(association);
                _context.SaveChanges();
                return RedirectToAction("Product", association.ProductId);
            }
            else
            {
                return View("Product", association);
            }
        }

        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            ViewBag.Categories = _context.Categories
                .ToList();
            return View();
        }

        [HttpPost("Categories/CreateCategory")]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Redirect("/Categories");
            }
            else
            {
                return View("Categories");
            }
        }

        [HttpGet("Categories/{CategoryId}/Delete")]
        public IActionResult DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Redirect("/Categories");
        }

        [HttpGet("Categories/{CategoryId}")]
        public IActionResult Category(int CategoryId)
        {
            ViewBag.Category = _context.Categories
                .Include(c => c.CategoryProducts)
                    .ThenInclude(cp => cp.Product)
                .FirstOrDefault(c => c.CategoryId == CategoryId);

            ViewBag.NotProducts = _context.Products
                .Include(p => p.ProductCategories)
                .Where(p => p.ProductCategories.All(pc => pc.CategoryId != CategoryId))
                .ToList();
                return View();
        }

        [HttpPost("Categories/{CategoryId}/AddProduct")]
        public IActionResult AddProduct(Association association)
        {
            if (ModelState.IsValid)
            {
                _context.Associations.Add(association);
                _context.SaveChanges();
                return RedirectToAction("Category", association.CategoryId);
            }
            else
            {
                return View("Category", association);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
