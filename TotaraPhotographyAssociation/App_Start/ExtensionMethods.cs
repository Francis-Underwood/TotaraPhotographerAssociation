using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace TotaraPhotographyAssociation
{
    /*
     *  Vincent: It is a class that hosts a group of extention methods for System.Security.Principal.IIdentity 
     *  The methods can be called on an object that implements IIdentity.
     *  Can be used as: User.Identity.IsAdminOrFull()
     */
    public static class ExtensionMethods
    {
        /* 
         * Vincent: return true if the currently logged user is associate or full
         * 
         */
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

        /* 
         * Vincent: return true if the currently logged user is associate, full, inactive or expired  
         */
        public static bool IsFrontEndUser(this System.Security.Principal.IIdentity identity)
        {
            ClaimsIdentity userIdentity = (ClaimsIdentity)identity;
            List<Claim> roles = userIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            bool isFrontEndUser = false;
            foreach (Claim c in roles)
            {
                if (c.Value.ToString() == "full" || c.Value.ToString() == "associate" || c.Value.ToString() == "expired" || c.Value.ToString() == "inactive")
                {
                    isFrontEndUser = true;
                    break;
                }
            }
            return isFrontEndUser;
        }

        /* 
         * Vincent: return true if the currently logged user is admin  or full member
         */
        public static bool IsAdminOrFull(this System.Security.Principal.IIdentity identity)
        {
            ClaimsIdentity userIdentity = (ClaimsIdentity)identity;
            List<Claim> roles = userIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            bool isAdminOrFull = false;
            foreach (Claim c in roles)
            {
                if (c.Value.ToString() == "admin" || c.Value.ToString() == "full")
                {
                    isAdminOrFull = true;
                    break;
                }
            }
            return isAdminOrFull;
        }

        /* 
         * Vincent: return true if the currently logged user is admin 
         */
        public static bool IsAdmin(this System.Security.Principal.IIdentity identity)
        {
            ClaimsIdentity userIdentity = (ClaimsIdentity)identity;
            List<Claim> roles = userIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
            bool isAdmin = false;
            foreach (Claim c in roles)
            {
                if (c.Value.ToString() == "admin")
                {
                    isAdmin = true;
                    break;
                }
            }
            return isAdmin;
        }

    }

}