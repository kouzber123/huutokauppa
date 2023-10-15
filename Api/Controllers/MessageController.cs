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
    public class MessageController : BaseController
    {
        private readonly IMessage _message;
        public MessageController(IMessage message)
        {
            _message = message;
        }

        [HttpGet("commentList")]

        public async Task<ActionResult<List<MessageDto>>> GetMessagesAsync()
        {
            return await _message.GetMessageListAsync();
        }
    }
}
