using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeTwo.Models
{
    public class TriviaSpecies : TopicCategory
    {
        private int _actualLifespan;
        private string guessFormat = "{0}-{1}";

        public string Name { get; set; }
        public List<Tuple<int, int>> PossibleLifespans;

        public TriviaSpecies()
        {
            PossibleLifespans = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0, 50),
                new Tuple<int, int>(51, 100),
                new Tuple<int, int>(101, 200),
                new Tuple<int, int>(201, 500),
                new Tuple<int, int>(501, 10000)
            };
        }

        public TriviaSpecies(string name, string lifespan) : this()
        {
            Name = name;

            int n;
            if(int.TryParse(lifespan, out n))
            {
                _actualLifespan = n;
            }
            else if (lifespan.ToLower().Equals("unknown"))
            {
                _actualLifespan = 0;
            }
            else
            {
                _actualLifespan = 1000;
            }

            GuessingOptions = GenerateGuessingOptions();
            Answer = GetTriviaAnswer();
        }

        public override string GetTriviaQuestion()
        {
            return string.Format("The species \"{0}\" has an average lifespan of how many years?", Name);
        }

        private string GetTriviaAnswer()
        {
            foreach(var range in PossibleLifespans)
            {
                if(_actualLifespan >= range.Item1 && _actualLifespan <= range.Item2)
                {
                    return string.Format(guessFormat, range.Item1, range.Item2);
                }
            }

            return string.Empty;
        }

        private List<string> GenerateGuessingOptions()
        {
            List<string> conversion = new List<string>();

            foreach (var range in PossibleLifespans)
            {
                conversion.Add(string.Format(guessFormat, range.Item1, range.Item2));
            }

            return conversion;
        }
    }
}