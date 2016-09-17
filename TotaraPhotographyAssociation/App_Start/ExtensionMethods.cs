using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace TotaraPhotographyAssociation
{
    public static class ExtensionMethods
    {
        public static bool IsUserInFullOrAssociate(this System.Security.Principal.IIdentity identity)
        {
            // http://stackoverflow.com/questions/21688928/asp-net-identity-get-all-roles-of-logged-in-user
            // http://stackoverflow.com/questions/27139068/get-asp-net-identity-current-user-in-view
            // http://stackoverflow.com/questions/23049813/asp-net-identity-2-0-check-if-current-user-is-in-role-isinrole

            ClaimsIdentity userIdentity = (ClaimsIdentity)identity;
            List<Claim> roles = userIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();

            bool isFull = false;

            foreach (Claim c in roles)
            {
                if (c.Value.ToString() == "full" || c.Value.ToString() == "associate")
                {
                    isFull = true;
                    break;
                }
            }

            return isFull;
        }
    }

}