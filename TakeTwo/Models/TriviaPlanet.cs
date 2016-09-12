using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeTwo.Models
{
    public class TriviaPlanet : TopicCategory
    {
        private List<PossibleClimates> _actualClimates;

        public string Name { get; set; }
        public enum PossibleClimates
        {
            Temperate,
            Tropical,
            Frozen,
            Murky,
            Arid,
            Windy,
            Hot,
            Artificial,
            Frigid,
            Humid,
            Moist,
            Polluted,
            Unknown,
            Superheated,
            Subartic,
            Artic
        };

        public TriviaPlanet(string name, List<string> climates)
        {
            Name = name;
            var actualClimates = new List<PossibleClimates>();

            foreach(string climate in climates)
            {
                string artificialCheck = climate; //Some climates are artificial, but I want to group them all together
                if (climate.ToLower().Contains("artificial"))
                {
                    artificialCheck = "artificial";
                }

                switch (artificialCheck)
                {
                    case "temperate": actualClimates.Add(PossibleClimates.Temperate); break;
                    case "tropical": actualClimates.Add(PossibleClimates.Tropical); break;
                    case "frozen": actualClimates.Add(PossibleClimates.Frozen); break;
                    case "murky": actualClimates.Add(PossibleClimates.Murky); break;
                    case "arid": actualClimates.Add(PossibleClimates.Arid); break;
                    case "windy": actualClimates.Add(PossibleClimates.Windy); break;
                    case "hot": actualClimates.Add(PossibleClimates.Hot); break;
                    case "artificial": actualClimates.Add(PossibleClimates.Artificial); break;
                    case "frigid": actualClimates.Add(PossibleClimates.Frigid); break;
                    case "humid": actualClimates.Add(PossibleClimates.Humid); break;
                    case "moist": actualClimates.Add(PossibleClimates.Moist); break;
                    case "polluted": actualClimates.Add(PossibleClimates.Polluted); break;
                    case "unknown": actualClimates.Add(PossibleClimates.Unknown); break;
                    case "superheated": actualClimates.Add(PossibleClimates.Superheated); break;
                    case "subartic": actualClimates.Add(PossibleClimates.Subartic); break;
                    case "artic": actualClimates.Add(PossibleClimates.Artic); break;
                }
            }

            _actualClimates = actualClimates;
            GuessingOptions = GenerateGuessingOptions();
            Answer = GetTriviaAnswer();
        }

        public override string GetTriviaQuestion()
        {
            return string.Format("What is the prevailing climate on the planet \"{0}\"? ", Name);
        }

        private string GetTriviaAnswer()
        {
            return _actualClimates[0].ToString();
        }

        private List<string> GenerateGuessingOptions()
        {
            var options = new List<string>();
            options.Add(_actualClimates[0].ToString());

            Random r = new Random();
            int randomChoice = 0;

            for(int i = 0; i < 4; i++)
            {
                //Make sure I don't put multiple options that are the same into the guessable list
                randomChoice = r.Next(0, Enum.GetNames(typeof(PossibleClimates)).Length);
                if (options.Contains(((PossibleClimates)randomChoice).ToString()))
                {
                    i--;
                    continue;
                }

                options.Add(((PossibleClimates)randomChoice).ToString());
            }

            //This is a really simple shuffle. It's not that random, but it doesn't really need to be
            return options.OrderBy(a => Guid.NewGuid()).ToList();
        }
    }
}