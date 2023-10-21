using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Repositories.Interface;
using huutokauppa.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ParticipateAuctionController : BaseController
    {
        private readonly IParticipate _participate;
        public ParticipateAuctionController(IParticipate participate)
        {
            _participate = participate;
        }

        [HttpPost("{auctionId}")]
        public async Task<ActionResult> JoinAuction(int auctionId, int userId)
        {
            return await _participate.JoinAsParticipatorAsync(auctionId, userId);

        }
    }
}
