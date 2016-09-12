using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TakeTwo.ApiAccessor;
using TakeTwo.Models;

namespace TakeTwo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            OptionsCacheFactory.ResetCache();
            return View();
        }

        public ActionResult LoadRandomPlanet()
        {
            GuessingGameOptionCollection model = null;
            SourcePlanet source = Task.Run(StarWarsAccessor.LoadPlanet).Result;
            if (source != null)
            {
                TopicCategory category = new TriviaPlanet(source.name, source.climate.Trim().Split(',').ToList());
                model = new GuessingGameOptionCollection(category);
            }

            return PartialView("GuessingGamePartial", model);
        }

        public ActionResult LoadRandomSpecies()
        {
            GuessingGameOptionCollection model = null;
            SourceSpecies source = Task.Run(StarWarsAccessor.LoadSpecies).Result;
            if (source != null)
            {
                TopicCategory category = new TriviaSpecies(source.name, source.average_lifespan);
                model = new GuessingGameOptionCollection(category);
            }

            return PartialView("GuessingGamePartial", model);
        }

        public ActionResult Guess(string guess, string score)
        {
            ViewBag.Score = score + 1;
            return PartialView("ScorePartial");
        }
    }
}

