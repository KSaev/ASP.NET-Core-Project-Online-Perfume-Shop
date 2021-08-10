using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using static OnlinePerfumeShop.Area.Admin.AdminConstants;

namespace OnlinePerfumeShop.Infrastructure
{
    public static class ClaimPrincipalExtentions
    {
        public static string GetUserId(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.NameIdentifier).Value;
        public static bool IsAdministrator(this ClaimsPrincipal user) => user.IsInRole(AdministratorRoleName);
    }
}
