using ApiProject.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public CategoriesController(ApiDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}/products")]
        public IActionResult GetWithProduct(int id)
        {
          var data=  _context.Categories.Include(x => x.Products).SingleOrDefault(x =>x.Id == id);
            if(data==null)
            {
                return NotFound("kayıt bulunamadı");
            }
            return Ok(data);
        }
    }
}
