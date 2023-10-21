using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Data.Repositories.Interface
{
    public interface IParticipate
    {
        //USER JOIN AUCTION
        //added to participant list
        
          Task<ActionResult> JoinAsParticipatorAsync(int auctionId, int userId);
          Task<ActionResult> RemoveParticipatorAsync(int auctionId, int userId);
        //participant list cointains messages, bids
        //in here everything is initialised
        //in bid repo we add bids to list
        //in messages we add messages
    }
}
