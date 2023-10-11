using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.context;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Models;
using huutokauppa.Data.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace huutokauppa.Data.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly Datacontext _datacontext;
        public ProductRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<ActionResult<CreateProductDto>> CreateProductAsync(CreateProductDto product)
        {
            var ownerId = await _datacontext.Users.FirstOrDefaultAsync(x => x.Id == product.OwnerId);

            if (ownerId is null) return null;
            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                OwnerName = $"{ownerId.Fname} {ownerId.Lname}",
                OwnerId = ownerId.Id

            };

            _datacontext.Products.Add(newProduct);
            await _datacontext.SaveChangesAsync();

            return new OkObjectResult($"new item has been added to auction {newProduct.Name}");

        }

        public async Task<ActionResult<ProductDto>> GetProductAsync(int id)
        {
            var product = await _datacontext.Products.FirstOrDefaultAsync(x => x.Id == id);
            var productOwner = await _datacontext.Users.FirstOrDefaultAsync(x => x.Id == product.OwnerId);
            if (product is null) return new NotFoundResult();

            var foundItem = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                OwnerId = productOwner.Id,
                OwnerName = $"{productOwner.Fname} {productOwner.Lname}"

            };

            return new OkObjectResult(foundItem);
        }

        public async Task<ActionResult<List<ProductDto>>> GetProductListAsync()
        {
            var productList = await _datacontext.Products.ToListAsync();
            var newList = new List<ProductDto>();
            foreach (var product in productList)
            {
                var productOwner = await _datacontext.Users.FirstOrDefaultAsync(x => x.Id == product.OwnerId);
                var foundItem = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    OwnerId = productOwner.Id,
                    OwnerName = $"{productOwner.Fname} {productOwner.Lname}"

                };
                newList.Add(foundItem);
            }

            return new OkObjectResult(newList);

        }
    }
}
