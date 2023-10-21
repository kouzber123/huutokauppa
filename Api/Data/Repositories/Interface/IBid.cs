using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Data.Repositories.Interface
{
    public interface IBid
    {
        //user can add money to specifc auction
        //we add to the list and to db cannort be cancelledx
        //get the bid  list
        Task<ActionResult<List<BidDto>>> GetBidListAsync(int auctionId);
        //get by  bid by id?
        Task<ActionResult<BidDto>> GetBidByIdAsync(int id);
        //bid needs to be pushed to auction bid list and saved to bid table
        Task<ActionResult> CreateBidAsync(int auctionId, BidDto bidDto);

        //dont return bid when creating state will handle it client side
        //only when re called we return new list
    }
}
