using CM3070.DbModelCore;
using CM3070.DbRepositoryCore;
using CM3070_API.Contracts.v1;
using Microsoft.AspNetCore.Mvc;

namespace CM3070_API.Controllers.v1
{
    
    [ApiController]
    [Route("api/vi/[controller]")]
    public class DataController : Controller
    {
        private IHttpContextAccessor _httpContext;
        private IRepositoryCore _repositoryCore;
        public DataController( IHttpContextAccessor httpContext, IRepositoryCore repositoryCore ) { 

            _httpContext = httpContext;
            _repositoryCore = repositoryCore;
        }


        [HttpGet(ApiRoutes.Posts.GetDemographic)]
        public async Task<IActionResult> GetDemographic ( [FromRoute] int pid )
        {

            return Ok(await _repositoryCore.GetDemographic(pid));
        }

        [HttpPost(ApiRoutes.Posts.PhysicianSearch)]
        public async Task<IActionResult> PhysicianSearch ( [FromBody] PhysicianSearchParams psearch )
        {

            return Ok(_repositoryCore.PhysicianSearch(psearch.Id, psearch.LastName));
        }

        [HttpPost(ApiRoutes.Posts.GetSchedule)]
        public async Task<IActionResult> GetSchedule ( )
        {

            return Ok(_repositoryCore.GetSchedule());
        }

        [HttpGet(ApiRoutes.Posts.GetProviders)]
        public async Task<IActionResult> GetProviders ()
        {

            return Ok(_repositoryCore.GetProviders());
        }

        [HttpGet(ApiRoutes.Posts.GetProvider)]
        public async Task<IActionResult> GetProvider ( [FromRoute] string id )
        {

            return Ok(_repositoryCore.GetProvider(id));
        }

        [HttpPost(ApiRoutes.Posts.GetScheduleByDate)]
        public async Task<IActionResult> GetScheduleByDate (DateTime dateTime)
        {

            return Ok(_repositoryCore.GetSchedule(dateTime));
        }

        [HttpGet(ApiRoutes.Posts.GetScheduleEvent)]
        public async Task<IActionResult> GetScheduleEvent ( [FromRoute] int id )
        {

            return Ok(_repositoryCore.GetScheduleEvent(id));
        }


        [HttpGet(ApiRoutes.Posts.UpdateProvider)]
        public async Task<IActionResult> UpdateProvider ( [FromBody] Provider provider )
        {

            return Ok(_repositoryCore.UpdateProvider(provider));
        }

        


    }
}
