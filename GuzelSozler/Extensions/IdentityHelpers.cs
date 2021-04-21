using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GuzelSozler.Extensions
{
    public static class IdentityHelpers
    {
        //User.FindFirstValue(ClaimTypes.NameIdentifier);  -- alanını tekrar tekrar kullanmamak için class ekledik
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
