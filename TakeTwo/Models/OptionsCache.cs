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
        public List<int> seenSpecies { get; }
        public List<int> seenPlanets { get; }

        public OptionsCache()
        {
            seenSpecies = new List<int>();
            seenPlanets = new List<int>();
        }
    }
}