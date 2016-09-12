using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TakeTwo.Models;

namespace TakeTwo.ApiAccessor
{
    public static class StarWarsAccessor
    {
        private static string baseUri = "http://swapi.co/api/";
        private static string planetAccessor = "planets";
        private static string speciesAccessor = "species";
        private static string format = "{0}/{1}/";

        public static async Task<SourcePlanet> LoadPlanet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                HttpResponseMessage response = await client.GetAsync(
                    string.Format(format, planetAccessor, GetRandomEntry(0)));

                if (response.IsSuccessStatusCode)
                {
                    SourcePlanet planet = await response.Content.ReadAsAsync<SourcePlanet>();
                    return planet;
                }
            }

            return null;
        }

        public static async Task<SourceSpecies> LoadSpecies()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                HttpResponseMessage response = await client.GetAsync(
                    string.Format(format, speciesAccessor, GetRandomEntry(1)));

                if (response.IsSuccessStatusCode)
                {
                    SourceSpecies planet = await response.Content.ReadAsAsync<SourceSpecies>();
                    return planet;
                }
            }

            return null;
        }

        //Make sure the user doesn't see duplicate entries until they've seen them all
        private static int GetRandomEntry(int type) //Species: 0, Planets: 1
        {
            Random r = new Random();
            var cacheStore = OptionsCacheFactory.GetCache();
            var cache = new List<int>();

            if (type == 0)
            {
                cache = cacheStore.seenSpecies;
            }
            else if (type == 1)
            {
                cache = cacheStore.seenPlanets;
            }

            int randomValue;
            do
            {
                randomValue = r.Next(1, 21); //I know there are at least 20 entries and am scoping it to that for the purposes of the example code piece
            }
            while (cache.Contains(randomValue) && cache.Count <= 19);

            cache.Add(randomValue);
            return randomValue; 
        }
    }
}