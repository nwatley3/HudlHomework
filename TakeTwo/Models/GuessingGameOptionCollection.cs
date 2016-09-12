using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeTwo.Models
{
    public class GuessingGameOptionCollection
    {
        public TopicCategory Topic { get; set; }
        public List<string> GuessingGameOptions { get; set; }
        
        public GuessingGameOptionCollection(TopicCategory topic)
        {
            Topic = topic;
            GuessingGameOptions = Topic.GuessingOptions;
        }
    }
}