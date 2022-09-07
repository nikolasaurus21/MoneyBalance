using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyBalance.Models;
using System.Linq;

namespace MoneyBalance.Models
{
    [Route("api/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MoneyBalanceContext _context;

        public UserController(MoneyBalanceContext context)
        {
            _context = context;
        }

       // [HttpGet]

        //public async Task<ActionResult<List<UserDTO>>> GetAll() 
       // { 
          //  var allusers = await _context.Users.Where(u => u.Id > 1)
       // }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers (int id)
        {
            var result = await _context.Users.FindAsync(id);

            if (result == null)
            {
                return NotFound("That user doesnt exist");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddNewUser (UserDTO userDTO)
        {
            var user = new User
            {
                
                FirstName= userDTO.FirstName,
                LastName= userDTO.LastName
               
            };
             
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetUsers),new {id =user.Id }, user);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            var usertodelete = await _context.Users.FindAsync(id);
            if (usertodelete == null)
            {
                return NotFound("That user doesnt exist");
            }

            _context.Users.Remove(usertodelete);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
    }
}
