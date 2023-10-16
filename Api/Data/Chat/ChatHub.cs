using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Data.Helpers;
using Api.Data.Models;
using Api.Data.Repositories.Interface;
using huutokauppa.Data.Repositories.Interface;
using Microsoft.AspNetCore.SignalR;

namespace Api.Data.Chat
{
    public class ChatHub : Hub
    {
        private readonly IMessage _message;

        private readonly IProduct _product;
        public ChatHub(IMessage message, IProduct product)
        {
            _message = message;
            _product = product;

        }
        public async Task SendProductComments(Message message)
        {
            var newMsg = new Message
            {
                Sender = message.Sender,
                Content = message.Content
            };
            Console.WriteLine(message.Sender);
            await _message.SaveMessageAsync(newMsg);
            await Clients.Caller.SendAsync("LoadComments", message);
        }
    }
}

