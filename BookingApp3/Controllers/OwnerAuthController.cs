using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookingApp3.Models;
using Microsoft.Extensions.Options;
using BookingApp3.Helpers;
using Microsoft.AspNetCore.Cors;
using BookingApp3.Auth;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookingApp3.Controllers
{
    [Produces("application/json")]
    [Route("api/OwnerAuth")]
    public class OwnerAuthController : Controller
    {

        private readonly    aContext _context;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public OwnerAuthController(aContext context, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _context = context;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }
        // GET: api/OwnerAuth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OwnerAuth/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/OwnerAuth
        [HttpPost("login")]

        [EnableCors("AllowCors")]
        public async Task<IActionResult> Post([FromBody]Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(owner.Email, owner.Passcode);

            if (identity== null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }
            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, owner.Email, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }

        //private bool GetClaimsIdentity(string email, string password)
        //{
        //    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        //        return false;
        //    else
        //    {
        //        // get the user to verifty
        //        bool result=_context.Owner.Any(e => e.Email == email && e.Passcode == password);
        //        if (result)
        //            return true;
        //        else
        //           return false;
        //    }
        //}
        private async Task<ClaimsIdentity> GetClaimsIdentity(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            bool userToVerify = _context.Owner.Any(e => e.Email == email && e.Passcode == password);

            if (userToVerify == false)
                return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            else
            { 
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(email,password));
            }

            // Credentials are invalid, or account doesn't exist
           
        }
        // PUT: api/OwnerAuth/5
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
