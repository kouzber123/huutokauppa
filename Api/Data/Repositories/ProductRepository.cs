using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Api.Data.Helpers;
using Api.Data.Models;
using Api.Data.Repositories.Interface;
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

        private readonly IModelChanger _modelChanger;

        public ProductRepository(Datacontext datacontext, IModelChanger modelChanger)
        {
            _modelChanger = modelChanger;


            _datacontext = datacontext;
        }

        public async Task<ActionResult<CreateProductDto>> CreateProductAsync(ProductDto product)
        {

            var ownerId = await _datacontext.Users.FirstOrDefaultAsync(x => x.Id == product.OwnerId);

            if (ownerId is null) return null;

            var photos = new List<Photo>();

            foreach (var photoItem in product.Photos)
            {
                var photo = new Photo
                {
                    Url = photoItem.Url,
                    ReferenceId = photoItem.ReferenceId,
                };
                photos.Add(photo);
            };
            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                Description = product.Description,
                Quantity = product.Quantity,
                Photos = photos,
                OwnerId = product.OwnerId,
                OwnerName = $"{ownerId.Fname} {ownerId.Lname}"
            };


            _datacontext.Products.Add(newProduct);
            await _datacontext.SaveChangesAsync();

            return new OkObjectResult($"new item has been added to auction {newProduct.Name}");

        }

        public async Task<Product> GetLatestProductAsync(int userId)
        {
            var userProduct = await _datacontext.Products.Where(x => x.OwnerId == userId).OrderByDescending(d => d.Id).FirstOrDefaultAsync();
            return userProduct;
        }

        public async Task<ActionResult<FullAuctionDto>> GetProductByIdAsync(int id)
        {
            // Create an instance of ModelChanger and pass the Datacontext to it

            var auctionProduct = await _datacontext.Auctions
            .Include(b => b.Bids)
            .Include(m => m.Messages)
            .Include(p => p.Participates)
            .Include(p => p.Product)
            .ThenInclude(c => c.Photos)
            .FirstOrDefaultAsync(x => x.Id == id);
            var productOwner = await _datacontext.Users.FirstOrDefaultAsync(x => x.Id == auctionProduct.AuctioneerId);
            if (auctionProduct is null) return new NotFoundResult();

            var photos = new List<PhotoDto>();
            var messages = new List<MessageDto>();
            var bids = new List<BidDto>();
            var product = _modelChanger.GetProductDto(auctionProduct.Product);
            messages = _modelChanger.GetMessageListDto(auctionProduct.Messages);
            bids = _modelChanger.GetBidListDto(auctionProduct.Bids);

            var participate = new List<ParticipateAuctionDto>();
            foreach (var participant in auctionProduct.Participates)
            {
                var participants = new ParticipateAuctionDto
                {
                    Id = participant.Id,
                    UserId = participant.UserId,
                    User = participant.User.Fname,
                    AuctionId = participant.AuctionId

                };
            }
            var foundItem = new FullAuctionDto
            {
                Id = auctionProduct.Id,
                AuctioneerId = auctionProduct.AuctioneerId,
                AuctionActive = auctionProduct.AuctionActive,
                AuctionDetails = auctionProduct.AuctionDetails,
                AuctionStartDate = auctionProduct.AuctionStartDate,
                FormattedAuctionStartDate = auctionProduct.FormattedAuctionStartDate,
                Region = auctionProduct.Region,
                Category = auctionProduct.Category,
                Product = product,
                HostName = product.OwnerName,
                ProductId = product.Id,
                Bids = bids,
                Messages = messages
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
