

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Newtonsoft.Json;
using BookingApp3.Auth;
using BookingApp3.Models;
using System;

namespace BookingApp3.Helpers
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string email, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = await jwtFactory.GenerateEncodedToken(email, identity),
                expires_in = (int)jwtOptions.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }

        internal static Task GenerateJwt(Owner identity, IJwtFactory jwtFactory, string email, JwtIssuerOptions jwtOptions, JsonSerializerSettings jsonSerializerSettings)
        {
            throw new NotImplementedException();
        }
    }
}
