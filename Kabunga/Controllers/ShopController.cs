using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kabunga.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Kabunga.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopRepository _shopRepository;
        public ShopController(ShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public async  Task<IActionResult> Index()
        {
            var products = await _shopRepository.GetAll();
            products = products.Take(10).ToList();
            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _shopRepository.GetById(id);

            if (product != null)
                return View(product);
            return View();
        }
    }
}