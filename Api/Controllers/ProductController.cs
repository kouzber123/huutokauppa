using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace huutokauppa.Controllers
{
    public class ProductController : BaseController
    {
        //here we add product to the database
        //create product
        //product > when created it cannot be deleted until it is bought
        //timer event
        private readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet("List")]
        public async Task<ActionResult<List<ProductDto>>> GetProductList()
        {
            return await _product.GetProductListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FullAuctionDto>> GetProductById(int id)
        {

            return await _product.GetProductByIdAsync(id);
        }

        [HttpPost("create-auction")]

        public async Task<ActionResult<CreateProductDto>> CreateProduct([FromBody] ProductDto createProduct)
        {

            return await _product.CreateProductAsync(createProduct);
        }
    }
}
