using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeTwo.Models
{
    /// <summary>
    /// Cache for keeping track of what questions a user has seen so far
    /// </summary>
    public class OptionsCache
    {
        public List<int> SeenSpecies { get; }
        public List<int> SeenPlanets { get; }

        public OptionsCache()
        {
            SeenSpecies = new List<int>();
            SeenPlanets = new List<int>();
        }
    }
}