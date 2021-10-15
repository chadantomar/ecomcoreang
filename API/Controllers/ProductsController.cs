using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;

namespace API.Controllers
{

[ApiController]
[Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo )
        {
            _repo= repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }
         [HttpGet]
         [Route("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            var product = await _repo.GetProductByIdAsync(id); 
            return Ok(product);
        }
    }
}