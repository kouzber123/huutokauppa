using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace huutokauppa.Data.Repositories.Interface
{
    public interface IUser
    {
        Task<ActionResult<UserDto>> GetUserAsync(int id);
    }
}
