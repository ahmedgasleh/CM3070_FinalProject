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

        
    }
}
