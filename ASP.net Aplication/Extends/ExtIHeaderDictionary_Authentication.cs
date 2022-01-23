using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.net_Aplication.Extends {
    public static class ExtIHeaderDictionary_Authentication {
        public static String[] GetAuthentication(this IHeaderDictionary requestHeader) {
            //var s1 = requestHeader[HeaderNames.Authorization].ToString();
            //var s2 = s1.Split(" ")[1].Trim();
            //var s3 = Convert.FromBase64String(s2);
            //var s4 = Encoding.UTF8.GetString(s3).Split(":");
            //return s4;
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
