using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace BookingApp3.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        readonly ILogger<ValuesController> logger;

        public ValuesController(ILogger<ValuesController> _logger)
        {
            logger = _logger;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
          Assembly assem1 = Assembly.Load(AssemblyName.GetAssemblyName(@".\bin\Debug\netcoreapp2.0\bookingApp3.dll"));
            logger.LogInformation("Hello");
            logger.LogInformation(assem1.ToString());
            Type[] types = assem1.GetTypes();
            foreach (Type tc in types)

            {

                if (tc.IsAbstract)

                {

                    logger.LogInformation("Abstract Class : " + tc.Name);

                }

                else if (tc.IsPublic)

                {

                    logger.LogInformation("Public Class : " + tc.Name);

                }

                else if (tc.IsSealed)

                {

                    logger.LogInformation("Sealed Class : " + tc.Name);

                }



                //Get List of Method Names of Class

                MemberInfo[] methodName = tc.GetMethods();



                foreach (MemberInfo method in methodName)

                {

                    if (method.ReflectedType.IsPublic)

                    {

                        logger.LogInformation("Public Method : " + method.Name.ToString());

                    }

                    else

                    {

                        logger.LogInformation("Non-Public Method : " + method.Name.ToString());

                    }

                }

            }
                return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
