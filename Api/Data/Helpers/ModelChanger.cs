using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Api.Data.Models;
using Api.Data.Repositories.Interface;
using huutokauppa.Data.context;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Helpers
{
    public class ModelChanger : IModelChanger
    {
        public List<BidDto> GetBidListDto(List<Bid> bids)
        {

            // var bids = await _datacontext.Auctions.Include(b => b.Bids).FirstOrDefaultAsync(i => i.Id == auctionId);
            var bidsListDto = new List<BidDto>();
            foreach (var bid in bids)
            {
                var bidDto = new BidDto
                {
                    UserId = bid.UserId,
                    User = bid.User,
                    BidAmount = bid.BidAmount,

                };
                bidsListDto.Add(bidDto);
            }

            return bidsListDto;

        }
        public List<MessageDto> GetMessageListDto(List<Message> messages)
        {
            // var ms = await _datacontext.Auctions.Include(m => m.Messages).FirstOrDefaultAsync(i => i.Id == auctionId);

            var ms = new List<MessageDto>();
            foreach (var Message in messages)
            {
                var messageDto = new MessageDto
                {
                    Sender = Message.Sender,
                    Content = Message.Content,
                    Timestamp = Message.Timestamp,
                    UserId = Message.UserId,
                    AuctionId = Message.AuctionId
                };
                ms.Add(messageDto);
            }

            return ms;

        }

        public List<PhotoDto> GetPhotoListDto(List<Photo> photos)
        {
            var p = new List<PhotoDto>();
            foreach (var photo in photos)
            {
                var photoDto = new PhotoDto
                {
                    Id = photo.Id,
                    ReferenceId = photo.ReferenceId,
                    Url = photo.Url
                };
                p.Add(photoDto);
            }

            return p;
        }

        public ProductDto GetProductDto(Product product)
        {
            // var photos = new List<PhotoDto>();
            var photos = GetPhotoListDto(product.Photos);
            var productdto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                Description = product.Description,
                Quantity = product.Quantity,
                Photos = photos,
                OwnerId = product.OwnerId,
                OwnerName = product.OwnerName
            };

            return productdto;

        }
    }
}
