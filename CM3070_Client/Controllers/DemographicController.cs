using CM3070.DbRepositoryCore;
using Microsoft.AspNetCore.Mvc;

namespace CM3070_Client.Controllers
{
    public class DemographicController : Controller
    {
        public IConfiguration _configuration { get; }
        private IRepositoryCore _repositoryCore;

       
        public DemographicController( IConfiguration configuration, IRepositoryCore repositoryCore ) { 
            _configuration = configuration;
            _repositoryCore = repositoryCore;
        }
        public IActionResult Index ()
        {
            return View();
        }

        
        
    }
}
