using Microsoft.AspNetCore.Mvc;

namespace CM3070_Client.Controllers
{
    public class DemographicController : Controller
    {
        public IConfiguration _configuration { get; }
        public DemographicController( IConfiguration configuration ) { 
            _configuration = configuration;
        }
        public IActionResult Index ()
        {
            return View();
        }
    }
}
