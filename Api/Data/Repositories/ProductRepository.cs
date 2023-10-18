using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Api.Data.Models;
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

        public async Task<ActionResult<FullAuctionDto>> GetProductAsync(int id)
        {
            var auctionProduct = await _datacontext.Auctions
            .Include(b => b.Bids)
            .Include(a => a.AuctionParticipants)
            .Include(m => m.Messages)
            .Include(p => p.Product)
            .ThenInclude(c => c.Photos)
            .FirstOrDefaultAsync(x => x.Id == id);
            var productOwner = await _datacontext.Users.FirstOrDefaultAsync(x => x.Id == auctionProduct.AuctioneerId);
            if (auctionProduct is null) return new NotFoundResult();

            var photos = new List<PhotoDto>();

            foreach (var photo in auctionProduct.Product.Photos)
            {
                var photoDto = new PhotoDto
                {
                    Id = photo.Id,
                    ReferenceId = photo.ReferenceId,
                    Url = photo.Url
                };
                photos.Add(photoDto);
            }
            var product = new ProductDto
            {
                Id = auctionProduct.Product.Id,
                Name = auctionProduct.Product.Name,
                Price = auctionProduct.Product.Price,
                Image = auctionProduct.Product.Image,
                Description = auctionProduct.Product.Description,
                Quantity = auctionProduct.Product.Quantity,
                Photos = photos,
                OwnerId = auctionProduct.Product.OwnerId,
                OwnerName = auctionProduct.Product.OwnerName
            };

            var messages = new List<MessageDto>();
            foreach (var Message in auctionProduct.Messages)
            {
                var messageDto = new MessageDto
                {
                    Sender = Message.Sender,
                    Content = Message.Content,
                    Timestamp = Message.Timestamp

                };
                messages.Add(messageDto);
            }
            var bids = new List<BidDto>();
            foreach (var bid in auctionProduct.Bids)
            {
                var bidDto = new BidDto
                {
                    Id = bid.Id,
                    UserId = bid.UserId,
                    User = bid.User,
                    BidAmount = bid.BidAmount

                };
                bids.Add(bidDto);
            }
            var participants = new List<AuctionParticipantDto>();
            foreach (var participant in auctionProduct.AuctionParticipants)
            {
                var user = new AuctionParticipantDto
                {
                    Id = participant.Id,
                    User = $"{participant.User.Select(x => x.Fname).ToString()} {participant.User.Select(x => x.Lname).ToString()} ",

                };
                participants.Add(user);

            }
            var foundItem = new FullAuctionDto
            {
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
                Messages = messages,
                Bids = bids,
                AuctionParticipants = participants,
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
