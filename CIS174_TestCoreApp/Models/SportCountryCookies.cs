using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CIS174_TestCoreApp.Models
{
    public class SportCountryCookies
    {
        private const string MyCountries = "mycountries";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public SportCountryCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public SportCountryCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyCountriesIds(List<SportCountry> mycountries)
        {
            List<int> ids = mycountries.Select(t => t.CountryId).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            RemoveMyCountriesIds();
            responseCookies.Append(MyCountries, idsString, options);
        }

        public int[] GetMyTeamsIds()
        {
            string cookie = requestCookies[MyCountries];
            if(string.IsNullOrEmpty(cookie))
            {
                return new int[] { };
            }
            else
            {
                string[] temp = cookie.Split(Delimiter);
                int[] returnList = Array.ConvertAll(temp, int.Parse);
                return returnList;
            }
        }

        public void RemoveMyCountriesIds()
        {
            responseCookies.Delete(MyCountries);
        }
    }
}
