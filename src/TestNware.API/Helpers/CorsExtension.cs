using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNware.Helpers
{
    public static class CorsExtension
    {
        public static void LiberarCorsDomain(HttpResponse response)
        {
            if (!response.Headers.ContainsKey("Access-Control-Allow-Origin")) response.Headers.Add("Access-Control-Allow-Origin", "*");
            if (!response.Headers.ContainsKey("Access-Control-Allow-Headers")) response.Headers.Add("Access-Control-Allow-Headers", "*");
            if (!response.Headers.ContainsKey("Access-Control-Allow-Methods")) response.Headers.Add("Access-Control-Allow-Methods", "*");
        }
    }
}
