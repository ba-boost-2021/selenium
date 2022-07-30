using BilgeAdam.Automation.Context;
using BilgeAdam.Automation.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdam.Automation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindDbContext dbContext;

        public ProductController(NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductRequestDto data)
        {
            dbContext.Products.Add(new Entities.Product
            {
                ProductName = data.Name,
                CategoryID = data.CategoryId,
                UnitPrice = data.Price,
                UnitsInStock = data.Amount
            });
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = dbContext.Products.Select(s => new ProductItemDto
            {
                Name = s.ProductName,
                Category = s.Category.CategoryName,
                Amount = s.UnitsInStock,
                Price = s.UnitPrice.Value
            }).ToList();

            return Ok(result);
        }
    }
}