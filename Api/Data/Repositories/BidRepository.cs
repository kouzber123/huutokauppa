using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repositories.Interface;
using huutokauppa.Data.context;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class BidRepository : IBid
    {
        private readonly Datacontext _datacontext;
        public BidRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<ActionResult> CreateBidAsync(int auctionId, BidDto bidDto)
        {
            var CurrentAuction = await _datacontext.Auctions.FirstOrDefaultAsync(x => x.Id == auctionId);
            var CurrentUser = await _datacontext.Users.FirstOrDefaultAsync(x => x.Id == bidDto.UserId);

            if (CurrentAuction is null || CurrentUser is null) return new NotFoundResult();

            var bid = new Bid
            {
                UserId = CurrentUser.Id,
                User = $"{CurrentUser.Fname} {CurrentUser.Lname}",
                BidAmount = bidDto.BidAmount
            };

            CurrentAuction.Bids.Add(bid);
            await _datacontext.Bids.AddAsync(bid);
            await _datacontext.SaveChangesAsync();

            return new OkResult();

        }

        public Task<ActionResult<BidDto>> GetBidByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<BidDto>>> GetBidListAsync(int auctionId)
        {
            throw new NotImplementedException();
        }
    }
}
