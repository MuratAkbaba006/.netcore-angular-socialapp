using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Data;
using ServerApp.DTO;
using ServerApp.Models;

namespace ServerApp.Controllers
{

   [Authorize]//productscontrollers metodlarına ulaşım token ile olmak zorunda 
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {

        private readonly SocialContext _context;
        public ProductsController(SocialContext context){
            _context=context;

        }

        [HttpGet]
        [AllowAnonymous] //bunu diyerek tüm kullanıcıların get metodununu kulannmasına izin verdik.
        public async Task<ActionResult> GetProducts()
        {

            var products=await _context.Products.Select(p=> ProductToDTO(p)).ToListAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id){

            var p =await _context.Products.FindAsync(id);
            if(p==null)
            {
                return NotFound();
                
            }
            return Ok(ProductToDTO(p));

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity){
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct),new {id=entity.Productid},ProductToDTO(entity));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct (int id,Product entity)
        {
              if(id!=entity.Productid)
              {
                  return BadRequest();
              }  
              var product=await _context.Products.FindAsync(id);
              if(product==null)
              {
                  return NotFound();
              }

              product.Name=entity.Name;
              product.price=entity.price;

              try{

                  await _context.SaveChangesAsync();
              }catch{

                  return NotFound();
              }

              return NoContent();//204 kodu 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
          var product=await _context.Products.FindAsync(id);
            if(product==null)
        {

            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();

        }

        private static ProductDTO ProductToDTO(Product p){

        return new ProductDTO()
        {
            Productid=p.Productid,
            Name=p.Name,
            price=p.price,
            isActive=p.isActive

            

        };
    }

    }

  
}