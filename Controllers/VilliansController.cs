using Microsoft.AspNetCore.Mvc;

namespace resource_permissions.Controllers
{
    [Route("api/[controller]")]
    public class VilliansController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult Edit(int id)
        {
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}