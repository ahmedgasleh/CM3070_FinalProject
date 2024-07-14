using CM3070.DbRepositoryCore;
using Microsoft.AspNetCore.Mvc;

namespace CM3070_Client.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFetchController : Controller
    {

        public IConfiguration _configuration { get; }
        private IRepositoryCore _repositoryCore;


        public DataFetchController ( IConfiguration configuration, IRepositoryCore repositoryCore )
        {
            _configuration = configuration;
            _repositoryCore = repositoryCore;
        }

        [HttpPost]
        [Route("GetProvider")]
        public async Task<IActionResult> GetProvider ( [FromBody] object id )
        {
            var result = _repositoryCore.GetProvider("1001");

            return PartialView("Popups/_ProviderDetail", result );
        }
    }
}
