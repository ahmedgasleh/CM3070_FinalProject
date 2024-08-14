using CM3070.DbModelCore;
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
            Provider provider = new Provider();
            provider.provider_no = data.Id;

            var result = _repositoryCore.GetProvider(data?.Id);

            if (result == null)
            {
                return PartialView("Popups/_ProviderDetail", provider);
            }

            return PartialView("Popups/_ProviderDetail", result );
        }

        [HttpPost]
        [Route("GetTaskDetails")]
        public async Task<IActionResult> GetTaskDetail ( [FromBody] RowId data )
        {
            var result = _repositoryCore.GetTask(data.Id);

            return PartialView("Sections/_taskDetail", result[0]);
        }

        [HttpPost]
        [Route("GetDecumentDetails")]
        public async Task<IActionResult> GetDecumentDetail ( [FromBody] RowId data )
        {
            var result = _repositoryCore.GetHomeDocuments(data.Id);

            return PartialView("Sections/_documentDetail", result[0]);
        }

        [HttpPost]
        [Route("CreateScheduleEvent")]
        public async Task<IActionResult> CreateScheduleEvent ( [FromBody] RowDate data )
        {
            var result = new ScheduleDate();

            result.sdate = data.datetime;


            return PartialView("Popups/_CreateCalanderEvent", result);
        }
    }
}
