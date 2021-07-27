using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopbridge.Model;

namespace Shopbridge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private IProductData _iProductData;
        private ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }


        // GET api/values
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productContext.Products.AsNoTracking().ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            try
            {
                Product product = await _productContext.Products.FindAsync(id);
                _productContext.Entry(product).State = EntityState.Detached;
                if (product != null)
                    return Ok(product);
                return NotFound($"Product with ID: {id} was not found");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //// POST api/values
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                await _productContext.Products.AddAsync(product);
                await _productContext.SaveChangesAsync();
                return RedirectToAction(nameof(GetProducts));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //// PUT api/values/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> EditProduct(Guid id, Product product)
        {
            try
            {
                var existingProduct = await _productContext.Products.FindAsync(id);
                _productContext.Entry(existingProduct).State = EntityState.Detached;
                if (existingProduct != null)
                {
                    product.id = existingProduct.id;
                    _productContext.Products.Update(product);
                    await _productContext.SaveChangesAsync();
                    return RedirectToAction(nameof(GetProducts));
                }
                return NotFound($"Product with ID: {id} was not found");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //// DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var existingProduct = await _productContext.Products.FindAsync(id);
                _productContext.Entry(existingProduct).State = EntityState.Detached;
                if (existingProduct != null)
                {
                    _productContext.Products.Remove(existingProduct);
                    await _productContext.SaveChangesAsync();
                    return Ok();
                }
                return NotFound($"Product with ID: {id} was not found");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
