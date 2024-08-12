using Microsoft.AspNetCore.Mvc;
using server.models;
using System.Net;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> users = new List<User> {new User("מוישי","הרב קוק 7","y8439343@gmail.com","11111111;",true),
                                                            new User("חני","הרב קוק 6","y8439343@gmail.com","12345678",false),
                                                            new User("תמי","הרב קוק 8","y8439343@gmail.com","22222222;",true),
                                                            new User("שרי","הרב קוק 0","y8439343@gmail.com","33333333;",false)

    };
    // GET: api/<UserController>
    //[HttpGet]
    //public IEnumerable<User> Get()
    //{
    //    return users;
    //}

    // GET api/<UserController>/5
    [HttpGet("users")]
    public User[] Get()
    {
      return users.ToArray();
    }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user != null)
                return user;
            return null;
        }

    // GET api/<UserController>/5
    [HttpGet]
    public IActionResult Get([FromQuery] string name, [FromQuery] string password)
    {
      if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
      {
        return BadRequest("Please provide both username and password.");
      }

      var user = users.FirstOrDefault(x => x.Name == name);
      if (user == null)
      {
        return NotFound("Username not found.");
      }

      // Implement secure password verification using the chosen hashing algorithm
      // Replace the following with your actual password verification logic
      // (This example assumes plain text comparison for demonstration purposes)
      if (user.Password == password)
      {
        return Ok(user); // Return user data or a success message
      }
      else
      {
        return BadRequest("Incorrect password.");
      }
    }
    // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var u = users.Find(x => x.Name == user.Name);
            if (u != null)
                return BadRequest();
            else
                users.Add(new User(user.Name, user.Address, user.Email, user.Password));
            return Ok(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var user = users.Find(x => x.Id == id);
            if (user != null)
            {
                user.Address = value.Address;
                user.Password = value.Password;
                user.Name = value.Name;
                user.Email = value.Email;
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user != null) { users.Remove(user); }
        }
    }
}
