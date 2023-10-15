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


        // //receive data
        // public async Task SendMessage(ChatMessage chatMessage)
        // {
        //     var dateformat = new DateFormatter(); //INVOKE our dateformatter
        //     var time = DateTime.Now.AddMinutes(-3);
        //     var newMessage = new ChatMessage
        //     {
        //         Sender = chatMessage.Sender,
        //         Content = chatMessage.Content,


        //     };
        //     Console.WriteLine(newMessage.Sender);
        //     //send back data
        //     await Clients.All.SendAsync("ReceiveMessage", newMessage);

        // }

        // public async Task JoinProductGroup(string productId)
        // {
        //     await Groups.AddToGroupAsync(Context.ConnectionId, productId);
        // }
        // Method to send product-specific comments
        public async Task SendProductComments(List<Message> comments)
        {

            var newMessage1 = new Message
            {
                Sender = "ligma balls",
                Content = "how old is this car",
                Timestamp = new(),
            };
            var newMessage2 = new Message
            {
                Sender = "liikeri",
                Content = "are the tires new?",
                Timestamp = new(),
            };
            comments.Add(newMessage1);
            comments.Add(newMessage2);


            await Clients.Caller.SendAsync("LoadComments", comments);
        }
    }
}

