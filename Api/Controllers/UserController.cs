using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.context;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;


namespace huutokauppa.Controllers
{

    //USER controller
    /*
    responsible user related commands get user

    delete user
    edit user details
    post user details
    */
    public class UserController : BaseController
    {
        private readonly Datacontext _datacontext;
        private readonly IUser _user;
        public UserController(Datacontext datacontext, IUser user)
        {
            _user = user;
            _datacontext = datacontext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {

            return await _user.GetUserAsync(id);
        }
    }
}
