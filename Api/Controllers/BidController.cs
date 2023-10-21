using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repositories.Interface;
using huutokauppa.Controllers;
using huutokauppa.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BidController : BaseController
    {
        private readonly IBid _bid;
        public BidController(IBid bid)
        {
            _bid = bid;
        }


        [HttpPost("{auctionId}")]

        public async Task<ActionResult> CreateBid(int auctionId, BidDto bidDto)
        {

            return await _bid.CreateBidAsync(auctionId, bidDto);
        }
    }
}
