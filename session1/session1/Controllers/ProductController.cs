using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using session1.Models;

namespace session1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product> {
            new Product {Id=1,Name="Thara'a",Description="This Is Product One"},
            new Product {Id=2,Name="Batol",Description="This Is Product Two"},
            new Product {Id=3,Name="Ahmad",Description="This Is Product Three"},


        };
        [HttpGet("getAll")]

        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet ("{id}") ]

        public IActionResult GetById(int id)
        {
            var product = products.First(product => product.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]

        public IActionResult Add(Product  request)
        {
           if (request is null)
            {
                return BadRequest();
            }
            var product = new Product
            {
                Id= request.Id,
                Name =request.Name,
                Description =request.Description,
            };
            products.Add(product);//list
            return Ok(product);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product request)
        {
            var currentProduct = products.FirstOrDefault(product => product.Id == id);
            if(currentProduct is null)
            
                return NotFound();
            currentProduct.Name = request.Name;
            currentProduct.Description= request.Description;
            return Ok(currentProduct);



        }
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if (product is null)

                return NotFound();
            products.Remove(product);
            return Ok();
        }
    }
}
 