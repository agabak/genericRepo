using Kabunga.Data;
using Kabunga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kabunga.Repositories
{
    public class ShopRepository : BaseRepository<Product>
    {
        public ShopRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async override Task<IEnumerable<Product>> GetAll()
        {
            var products = await base.GetAll();

            return products.OrderBy(x => x.Category).ToList();
        }
    }
}
