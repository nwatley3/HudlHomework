using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeTwo.Models
{
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