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
        public IActionResult Index()
        {
            var products = _shopRepository.GetAll();
            return View(products);
        }
    }
}