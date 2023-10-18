using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace huutokauppa.Data.Repositories.Interface
{
    public interface IProduct
    {
        Task<ActionResult<FullAuctionDto>> GetProductAsync(int id);
        Task<Product> GetLatestProductAsync(int userId);
        Task<ActionResult<List<ProductDto>>> GetProductListAsync();
        Task<ActionResult<CreateProductDto>> CreateProductAsync(ProductDto product);
    }
}
