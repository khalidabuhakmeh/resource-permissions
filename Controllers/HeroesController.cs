using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace resource_permissions.Controllers
{
    [Route("api/[controller]")]
    public class HeroesController : Controller
    {
        public static readonly dynamic[] Heroes = new dynamic[]
        {
            new {Id = 1, Name = "Captain America", Weapon = "Shield"},
            new {Id = 2, Name = "Iron Man", Weapon = "Arch Reactor"},
            new {Id = 3, Name = "Wonder Woman", Weapon = "Lasso"}
        };
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(Heroes);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            var hero = Heroes.FirstOrDefault(x => x.Id == id);
            if (hero == null)
                return NotFound();
            
            return Ok(hero);
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
