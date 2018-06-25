
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingApp3.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string email, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string email, string password);
        ClaimsIdentity GenerateClaimsIdentity(string email, int ownerId);
    }
}
