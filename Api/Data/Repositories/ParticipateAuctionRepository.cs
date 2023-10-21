using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Api.Data.Models;
using Api.Data.Repositories.Interface;
using huutokauppa.Data.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class ParticipateAuctionRepository : IParticipate
    {
        private readonly Datacontext _datacontext;
        public ParticipateAuctionRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        //    public int Id { get; set; }
        // public int UserId { get; set; }
        // public UserDto User { get; set; }
        // public int AuctionId { get; set; }
        // public AuctionDto Auction { get; set; }
        // public List<MessageDto> Messages { get; set; } = new List<MessageDto>();
        // public List<BidDto> Bids { get; set; } = new List<BidDto>();
 

        public async Task<ActionResult> JoinAsParticipatorAsync(int auctionId, int userId)
        {
            var auction = await _datacontext.Auctions.FirstOrDefaultAsync(i => i.Id == auctionId);
            var participate = await _datacontext.Participates.FirstOrDefaultAsync(i => i.AuctionId == auctionId);
            var user = await _datacontext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var participator = new Participate
            {
                User = user,
                Auction = auction
            };
            auction.Participates.Add(participator);
            await _datacontext.Participates.AddAsync(participator);
            await _datacontext.SaveChangesAsync();
            return new OkResult();

        }

        public Task<ActionResult> RemoveParticipatorAsync(int auctionId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
