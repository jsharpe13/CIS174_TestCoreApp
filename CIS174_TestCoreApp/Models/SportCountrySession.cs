using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CIS174_TestCoreApp.Models
{
    public class SportCountrySession
    {
        private const string CountryKey = "mycountries";
        private const string Countkey = "Countrycount";
        private const string GameKey = "game";
        private const string CategoryKey = "category";

        private ISession session { get; set; }
        public SportCountrySession(ISession session)
        {
            this.session = session;
        }

        public void SetMyCountries(List<SportCountry>countries)
        {
            session.SetObject(CountryKey, countries);
            session.SetInt32(Countkey, countries.Count);
        }
        public List<SportCountry> GetMyCountries() =>
            session.GetObject<List<SportCountry>>(CountryKey) ?? new List<SportCountry>();
        public int GetMyCountriesCount() => session.GetInt32(Countkey) ?? 0;



        public void SetActiveGame(int activeGame)
        {
            session.SetInt32(GameKey, activeGame);
        }
        public int GetActiveGame()
        {
            return (int)session.GetInt32(GameKey);
        }


        public void SetActiveCategory(int activeCategory)
        {
            session.SetInt32(CategoryKey, activeCategory);
        }
        public int GetActiveCategory()
        {
            return (int)session.GetInt32(CategoryKey);
        }

        public void RemoveMyCountries()
        {
            session.Remove(CountryKey);
            session.Remove(Countkey);
        }
    }
}
