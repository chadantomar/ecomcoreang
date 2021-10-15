using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;

namespace API.Controllers
{

[ApiController]
[Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storecontext;

        public ProductsController(StoreContext storeContext )
        {
            _storecontext= storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            
            var products = await this._storecontext.Products.ToListAsync();
            return Ok(products);
        }
         [HttpGet]
         [Route("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var product = await this._storecontext.Products.FindAsync(id); 
            return Ok(product);
        }
    }
}