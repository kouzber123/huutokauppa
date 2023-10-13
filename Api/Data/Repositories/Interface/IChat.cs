using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Data.Repositories.Interface
{
    public interface IChat
    {
        Task<ActionResult<ChatMessage>> SaveMessageAsync(ChatMessage message);
    }
}
