using Microsoft.AspNetCore.Mvc;
using server.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> categories = new List<Category> {
          new Category("צילום", "assets/courses-images/camera.jpg"),
          new Category("אנגלית", "assets/courses-images/english.jpg"),
          new Category("מחשבים", "assets/courses-images/learn.png") };
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categories;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var cat = categories.Find(x => x.Id == id);
            return cat;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category value)
        {
            Category newCategory = new Category(value.Name,value.Icon);
            categories.Add(newCategory);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category value)
        {
            var cat = categories.Find(x => x.Id == id);
            if (cat != null)
            {
                cat.Icon = value.Icon;
                cat.Name = value.Name;
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cat=categories.Find(x => x.Id == id);
            if (cat != null)
                categories.Remove(cat);
        }
    }
}
