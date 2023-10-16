using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.DTO;
using Api.Data.Models;
using Api.Data.Repositories.Interface;
using huutokauppa.Data.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class MessageRepository : IMessage
    {
        private readonly Datacontext _datacontext;
        public MessageRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<ActionResult<List<MessageDto>>> GetMessageListAsync()
        {
            var messages = await _datacontext.Messages.ToListAsync();

            var messageListDto = new List<MessageDto>();
            foreach (var message in messages)
            {
                var msg = new MessageDto
                {
                    Sender = message.Sender,
                    Content = message.Content,
                    Timestamp = message.Timestamp
                };

                messageListDto.Add(msg);
            }

            return new OkObjectResult(messageListDto);


        }

        public async Task<ActionResult<Message>> SaveMessageAsync(Message message)
        {
            await _datacontext.Messages.AddAsync(message);
            await _datacontext.SaveChangesAsync();
            return new OkResult();
        }
    }
}
