using System.Threading.Tasks;
using System.Web.Mvc;
using ErrorAPI.Repositories;

namespace ErrorAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ErrorRepository _errorRepository = new ErrorRepository();

        public async Task<ActionResult> Index()
        {
            var errors = await _errorRepository.GetErrors();
            return View(errors);
        }

        public async Task<ActionResult> Info(int id)
        {
            var error = await _errorRepository.GetError(id);
            return View(error);
        }
    }
}