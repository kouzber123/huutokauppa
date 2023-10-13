using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;
using Api.Data.Repositories.Interface;
using huutokauppa.Data.context;
using Microsoft.AspNetCore.Mvc;

namespace Api.Data.Repositories
{
    public class ChatMessageRepository : IChat
    {
        private readonly Datacontext _datacontext;
        public ChatMessageRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<ActionResult<ChatMessage>> SaveMessageAsync(ChatMessage message)
        {
            await _datacontext.ChatMessages.AddAsync(message);

            return new OkResult();
        }
    }
}
