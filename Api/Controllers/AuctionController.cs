using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Api.Data.Repositories.Interface;
using huutokauppa.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AuctionController : BaseController
    {
        private readonly IAuction _auction;
        public AuctionController(IAuction auction)
        {
            _auction = auction;
        }
        [HttpGet()]
        public async Task<ActionResult<List<AuctionProductDto>>> GetAuctionList()
        {

            return await _auction.GetAuctionListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<FullAuctionDto>> GetAuctionById(int id)
        {

            return await _auction.GetAuctionByIdAsync(id);
        }

        [HttpPost("createAuction")]

        public async Task<ActionResult> CreateAuction(int userId, AuctionProductDto auctionProductDto)
        {
            var result = await _auction.CeateAuctionAsync(userId, auctionProductDto);

            return new CreatedAtRouteResult("createAuction", result);
        }
    }
}
