using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace huutokauppa.Data.Repositories.Interface
{
    public interface IProduct
    {
        Task<ActionResult<ProductDto>> GetProductAsync(int id);
        Task<ActionResult<List<ProductDto>>> GetProductListAsync();
        Task<ActionResult<CreateProductDto>> CreateProductAsync(CreateProductDto product);
    }
}
