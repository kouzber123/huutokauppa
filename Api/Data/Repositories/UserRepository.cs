
using huutokauppa.Data.context;
using huutokauppa.Data.DTO;
using huutokauppa.Data.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace huutokauppa.Data.Repositories
{
    public class UserRepository : IUser
    {
        private readonly Datacontext _datacontext;
        public UserRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<ActionResult<UserDto>> GetUserAsync(int id)

        {
            var user = await _datacontext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user is null) return new NotFoundResult();

            var foundUser = new UserDto
            {
                Fname = user.Fname,
                Lname = user.Lname,
                Address = user.Address,
                Email = user.Email,

            };

            return new OkObjectResult(foundUser);
        }
    }
}
