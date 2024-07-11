using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
    private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        //Endpoint for products

        /* sync code for getting products
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = context.Products.ToList();
            return Ok(products);
        }
        */

        //async code for getting products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}