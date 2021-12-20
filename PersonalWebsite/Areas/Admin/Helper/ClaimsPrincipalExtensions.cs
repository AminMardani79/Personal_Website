using System.Security.Claims;

namespace PersonalWebsite.Areas.Admin.Helper
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("UserName");
        }
        public static string GetEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue("Email");
        }
    }
}
