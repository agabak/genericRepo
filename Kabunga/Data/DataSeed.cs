using Kabunga.Data;
using Kabunga.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kabunga.Data
{
    public class DataSeed
    {
        private readonly DataContext _ctx;
        private readonly IWebHostEnvironment _hosting;

        [Obsolete]
        public DataSeed(DataContext dataContext, IWebHostEnvironment hosting)
        {
            _ctx = dataContext;
            _hosting = hosting;
        }
        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            if(!_ctx.Products.Any())
            {
                var filePath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
                var jsonData = File.ReadAllText(filePath);

                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonData);
                _ctx.AddRange(products);

                var order = _ctx.Orders.FirstOrDefault(o => o.Id == 1);
                if(order != null)
                {
                    order.Items = new List<OrderItem>
                                        {
                                            new OrderItem
                                             {
                                               Product = products.FirstOrDefault(),
                                               Quantity = 5,
                                                UnitPrice = products.First().Price  
                                             }
                                        };
                }

                _ctx.SaveChanges();
            }
        }
    }
}
