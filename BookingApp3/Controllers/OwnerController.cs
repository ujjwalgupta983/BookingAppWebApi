using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookingApp3.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using BookingApp3.Helpers;

namespace BookingApp3.Controllers
{
    [Produces("application/json")]
    [Route("api/Owner")]
    public class OwnerController : Controller
    {
        private readonly aContext _context;
        
        private readonly IMapper _mapper;

        public OwnerController(aContext context)
        {
            _context = context;
           
        }
        // GET: api/Owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _context.Owner;
        }

        // GET: api/Owner/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Owner
        [HttpPost]
        [Produces("application/Json")]
        [EnableCors("AllowCors")]
        public async Task<IActionResult> Post([FromBody] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Owner.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = owner.OwnerId }, owner);

           

        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
