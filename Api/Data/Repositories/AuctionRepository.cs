using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Api.Data.Repositories.Interface;
using huutokauppa.Data.context;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Models;
using huutokauppa.Data.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class AuctionRepository : IAuction
    {
        private readonly Datacontext _datacontext;
        private readonly IProduct _product;
        public AuctionRepository(Datacontext datacontext, IProduct product)
        {
            _product = product;
            _datacontext = datacontext;
        }
        public async Task<ActionResult> CeateAuctionAsync(int userId, AuctionProductDto auctionProductDto)
        {

            var photos = new List<PhotoDto>();

            foreach (var photoItem in auctionProductDto.Photos)
            {
                var photo = new PhotoDto
                {
                    Url = photoItem.Url,
                    ReferenceId = photoItem.ReferenceId,
                };
                photos.Add(photo);
            };
            var newProductDto = new ProductDto
            {
                Name = auctionProductDto.Name,
                Price = auctionProductDto.Price,
                Image = auctionProductDto.Image,
                Description = auctionProductDto.Description,
                Quantity = auctionProductDto.Quantity,
                Photos = photos,
                OwnerId = userId,
                OwnerName = auctionProductDto.OwnerName
            };

            await _product.CreateProductAsync(newProductDto);

            var userNewProduct = await _product.GetLatestProductAsync(userId);

            var newAuction = new Auction
            {
                ProductId = userNewProduct.Id,
                AuctioneerId = userId,
                Product = userNewProduct,
                Region = auctionProductDto.Region,
                AuctionDetails = auctionProductDto.AuctionDetails,
                AuctionStartDate = auctionProductDto.AuctionStartDate,
                FormattedAuctionStartDate = auctionProductDto.FormattedAuctionStartDate,
                AuctionActive = auctionProductDto.AuctionActive,
                Category = auctionProductDto.Category,
                HostName = auctionProductDto.OwnerName

            };
            // await _datacontext.Products.AddAsync(newProduct);
            await _datacontext.Auctions.AddAsync(newAuction);
            var success = await _datacontext.SaveChangesAsync() > 0;
            if (!success) return new BadRequestObjectResult("Failed to save auction to database");

            return new OkResult();
        }

        public async Task<ActionResult<FullAuctionDto>> GetAuctionByIdAsync(int id)
        {
            var auction = await _product.GetProductByIdAsync(id);
            if (auction is null) return new NotFoundObjectResult("No auction found by given id");
            return auction;


        }

        public async Task<ActionResult<List<AuctionProductDto>>> GetAuctionListAsync()
        {
            var list = await _datacontext.Auctions
            .Include(x => x.Product)
            .ThenInclude(y => y.Photos)
            .ToListAsync();

            if (list is null) return new NoContentResult();

            return new OkObjectResult(list);
        }
    }
}
