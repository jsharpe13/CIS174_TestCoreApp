using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CIS174_TestCoreApp.Models
{
    public static class SportSessionExtensions
    {
        public static void SetObject<C>(this ISession session,
            string key, C value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static C GetObject<C>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return (value == null) ? default(C) :
                JsonConvert.DeserializeObject<C>(value);
        }
    }
}
