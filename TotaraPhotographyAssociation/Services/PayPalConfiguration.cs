using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;

namespace TotaraPhotographyAssociation.Services
{
    public class PayPalConfiguration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        static PayPalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        public static Dictionary<string, string> GetConfig()
        {
            // ConfigManager.Instance.GetProperties(); // it doesn't work on ASPNET 5
            return new Dictionary<string, string>() {
                { "clientId", "AZbTe-V1UhGgPkdALRNyIWAN5IZB9kfhYneI1iL-P5dnsE3IHbDyAjj5MeNFH_cNKl7eK2GVqCf5AJ_K" },
                { "clientSecret", "EFK1VysVtlj69_Wg9Zj7FTQi5jEb0nUF-cFORJ2cpIwP6j9fLaQTBsQy9V_Mo3DP9QcWT3zdZ6H3jZB4" }
            };
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(
                                            ClientId, ClientSecret, GetConfig()
                                        ).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetAPIContext(string accessToken = "")
        {
            var apiContext = new APIContext(
                                            string.IsNullOrEmpty(accessToken) ?
                                            GetAccessToken() : 
                                            accessToken
                                        );
            apiContext.Config = GetConfig();

            return apiContext;
        }
        }

}