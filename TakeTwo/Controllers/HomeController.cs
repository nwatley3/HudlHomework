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
            OptionsCacheFactory.ResetCache(); //Allow the user to play again if they refresh
            return View();
        }

        public ActionResult LoadRandomPlanet()
        {
            TopicCategory category = null;
            try
            {
                SourcePlanet source = Task.Run(StarWarsAccessor.LoadPlanet).Result;
                if (source != null)
                {
                    category = new TriviaPlanet(source.name, source.climate.Trim().Split(',').ToList());
                }
            }
            catch //I'm eating these exceptions now, but would be logging them in a production system
            {

            }

            return PartialView("GuessingGamePartial", category);
        }

        public ActionResult LoadRandomSpecies()
        {
            TopicCategory category = null;
            try
            {
                SourceSpecies source = Task.Run(StarWarsAccessor.LoadSpecies).Result;
                if (source != null)
                {
                    category = new TriviaSpecies(source.name, source.average_lifespan);
                }
            }
            catch //I'm eating these exceptions now, but would be logging them in a production system
            {

            }

            return PartialView("GuessingGamePartial", category);
        }
    }
}

