using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        //injecting DataContext
        public UsersController(DataContext context)
        {
            _context = context;
        }
        //getting all users 
        //  http://localhost:5000/api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users = await _context.Users.ToListAsync();
            return users;
        }
          //getting perticular user
        //  http://localhost:5000/api/users/2
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id){
            var user = await _context.Users.FindAsync(id);
            return user;
        }

    }
    
}