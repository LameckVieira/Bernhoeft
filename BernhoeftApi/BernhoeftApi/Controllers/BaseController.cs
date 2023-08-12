using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BernhoeftApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected int PegarIdUsuario() 
        {
            var userClaims = HttpContext.User.Claims;

            // Find the claim with the user's ID (assuming it's stored as a claim)
            var userIdClaim = userClaims.FirstOrDefault(c => c.Type == "jti");
             return Int32.Parse(userIdClaim.Value.ToString());
        }
    }
}
