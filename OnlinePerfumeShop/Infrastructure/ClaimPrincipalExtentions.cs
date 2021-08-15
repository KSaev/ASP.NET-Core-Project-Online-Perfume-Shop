namespace OnlinePerfumeShop.Infrastructure
{
    using System.Security.Claims;

    using static OnlinePerfumeShop.Area.Admin.AdminConstants;
    public static class ClaimPrincipalExtentions
    {
        public static string GetUserId(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.NameIdentifier).Value;
        public static bool IsAdministrator(this ClaimsPrincipal user) => user.IsInRole(AdministratorRoleName);
    }
}
