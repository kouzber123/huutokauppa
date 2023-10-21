using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Data.Repositories.Interface
{
    public interface IMessage
    {
        Task<ActionResult<Message>> SaveMessageAsync(Message message);

        Task<ActionResult<List<MessageDto>>> GetMessageListAsync();

        //create message
        //check if owner
        Task<ActionResult> CreateMessageAsync(int auctionId, MessageDto messageDto);

}
}
