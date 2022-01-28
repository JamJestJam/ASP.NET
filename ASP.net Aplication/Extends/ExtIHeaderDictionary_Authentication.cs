using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;
using System.Text;

namespace ASP.net_Aplication.Extends {
    public static class ExtIHeaderDictionary_Authentication {
        public static String[] GetAuthentication(this IHeaderDictionary requestHeader) {
            return Encoding.UTF8.GetString(
                    Convert.FromBase64String(
                        ((String)requestHeader[HeaderNames.Authorization])
                            .Split(" ")
                            .Last()
                            .Trim()))
                .Split(":");
        }
    }
}
