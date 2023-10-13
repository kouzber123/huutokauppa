using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Data.Helpers;
using Api.Data.Models;
using Api.Data.Repositories.Interface;
using Microsoft.AspNetCore.SignalR;

namespace Api.Data.Chat
{
    public class ChatHub : Hub
    {
        private readonly IChat _chat;
        public ChatHub(IChat chat)
        {
            _chat = chat;
        }


        //receive data
        public async Task SendMessage(ChatMessage chatMessage)
        {
            var dateformat = new DateFormatter(); //INVOKE our dateformatter
            var time = DateTime.Now.AddMinutes(-3);
            var newMessage = new ChatMessage
            {
                Sender = chatMessage.Sender,
                Content = chatMessage.Content,


            };
            Console.WriteLine(newMessage.Sender);



            //send back data
            await Clients.All.SendAsync("ReceiveMessage", newMessage);


        }
    }
}
