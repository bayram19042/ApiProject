using ApiProject.Contexts;
using ApiProject.Data;
using ApiProject.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class Products : ControllerBase
    {
        private readonly IProductRepository _repository;
        public Products(IProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async  Task<IActionResult> GetProducts()
        {

            var listVeri = await _repository.GetAll();
            if(listVeri.Count>0)
            {
                return Ok(listVeri);
            }
            else
            {
                return NotFound("Liste bulunamadı");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts([FromRoute]int id)
        {
            
            var gelen =  await _repository.GetById(id);
            if (gelen != null)
            {
                return Ok(gelen);
            }
            else
            {
                return NotFound("Kayıt bulunamadı...");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]Product product)
        {
            var urun = await _repository.Create(product);

            return Created(string.Empty, urun);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Product product)
        {
            var veri = _repository.GetById(product.Id);
            if(veri==null)
            {
                return NotFound("güncellenecek kayıt bulunamadı");
            }
            else
            {
                await _repository.UpdateAsync(product);
                return Ok();
            }
           
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _repository.RemoveAsync(id);
            return Ok();
        }
    }
}
