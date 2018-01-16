using System.Linq;
using Microsoft.Owin;

namespace pjo_api.Extentions
{
    public static class OwinContextExtentions
    {
        public static string GetUserId(this IOwinContext ctx)
        {
            var result = "0";
            var claim = ctx.Authentication.User.Claims.FirstOrDefault(c => c.Type == "UserID");
            if (claim != null)
            {
                result = claim.Value;
            }
            return result;
        }
    }
}