using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TakeTwo.Models
{
    /// <summary>
    /// Base class for our two categories of trivia questions
    /// </summary>
    public abstract class TopicCategory
    {
        public abstract string GetTriviaQuestion();
        public string Answer;
        public List<string> GuessingOptions;
    }
}