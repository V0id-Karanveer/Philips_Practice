using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MVVM_Prac.Model;
using Newtonsoft;
using Newtonsoft.Json;

namespace MVVM_Prac.ViewModel.Helpers
{
    class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string AUTOCOMPLETE_ENDPOINT = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS = "currentconditions/v1/{0}?apikey={1}";
        public const string API_KEY = "0xpRM0q1IZI0EGCq0B1bzsYrqAvoSAII";


        public static async Task<List<City>> GetCities(string req)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + string.Format(AUTOCOMPLETE_ENDPOINT, API_KEY, req);

            using (HttpClient client = new HttpClient())
            {
                var res = await client.GetAsync(url);
                string json = await res.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);

            }

            return cities;
        }

        public static async Task<CurrentConditions> GetCurrentConditions(string id)
        {
            CurrentConditions c = new CurrentConditions();

            string url = BASE_URL + string.Format(CURRENT_CONDITIONS, id, API_KEY);

            using(HttpClient cli = new HttpClient())
            {
                var res = await cli.GetAsync(url);
                string json = await res.Content.ReadAsStringAsync();
                c = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return c;
        } 
    }
}
