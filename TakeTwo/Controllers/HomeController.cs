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
            TopicCategory category = null;
            SourcePlanet source = Task.Run(StarWarsAccessor.LoadPlanet).Result;
            if (source != null)
            {
                category = new TriviaPlanet(source.name, source.climate.Trim().Split(',').ToList());
            }

            return PartialView("GuessingGamePartial", category);
        }

        public ActionResult LoadRandomSpecies()
        {
            TopicCategory category = null; 
            SourceSpecies source = Task.Run(StarWarsAccessor.LoadSpecies).Result;
            if (source != null)
            {
                category = new TriviaSpecies(source.name, source.average_lifespan);
            }

            return PartialView("GuessingGamePartial", category);
        }
    }
}

