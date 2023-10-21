using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using huutokauppa.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Data.Repositories.Interface
{
    public interface IAuction
    {
        //get product
        public Task<ActionResult<List<AuctionProductDto>>> GetAuctionListAsync();
        //create auction
        public Task<ActionResult> CeateAuctionAsync(int userId, AuctionProductDto auctionProductDto);
        //edit auction
        public Task<ActionResult<FullAuctionDto>> GetAuctionByIdAsync(int id);
        //remove auction

        //product will be added to auction
    }
}
