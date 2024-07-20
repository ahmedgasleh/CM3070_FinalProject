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
        public async Task<IActionResult> GetProvider ( [FromBody] Row data )
        {         
            
            var result = _repositoryCore.GetProvider(data?.Id);

            return PartialView("Popups/_ProviderDetail", result );
        }

        [HttpPost]
        [Route("GetTaskDetail")]
        public async Task<IActionResult> GetTaskDetail ( [FromBody] Row data )
        {
            var result = _repositoryCore.GetTask(Convert.ToInt32(data.Id));

            return PartialView("Sections/_taskDetail", result[0]);
        }

        [HttpPost]
        [Route("GetDecumentDetail")]
        public async Task<IActionResult> GetDecumentDetail ( [FromBody] Row data )
        {
            var result = _repositoryCore.GetHomeDocuments(Convert.ToInt32(data.Id));

            return PartialView("Sections/_documentDetail", result[0]);
        }
    }
}
