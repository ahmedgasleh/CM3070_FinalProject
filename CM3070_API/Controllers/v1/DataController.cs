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
        public async Task<IActionResult> GetDemographic ( [FromRoute] string pid )
        {
            var result = await _repositoryCore.GetDemographic(pid);
            if (result != null)
            {
                return Ok(result);
            }
            else return Ok(new Demographic());
                
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

        [HttpPost(ApiRoutes.Posts.UpdateScheduleEvent)]
        public async Task<IActionResult> UpdateScheduleEvent ( [FromBody] ScheduleDate scheduleDate )
        {

            return Ok(_repositoryCore.CreateScheduleEvent(scheduleDate));
        }




        [HttpPost(ApiRoutes.Posts.UpdateProvider)]
        public async Task<IActionResult> UpdateProvider ( [FromBody] Provider provider )
        {

            return Ok(_repositoryCore.UpdateProvider(provider));
        }

        [HttpPost(ApiRoutes.Posts.UpdateDemographic)]
        public async Task<IActionResult> UpdateDemographic ( [FromBody] DemographicUpdate demographic )
        {

            return Ok(_repositoryCore.UpdateDemographic(demographic));
        }

        

        [HttpGet(ApiRoutes.Posts.GetHomeTask)]
        public async Task<IActionResult> GetHomeTask ( [FromQuery] int id)
        {
            return Ok(_repositoryCore.GetTask(id));
        }

        [HttpGet(ApiRoutes.Posts.GetHomeDocuments)]
        public async Task<IActionResult> GetHomeDocuments ( [FromQuery] int id )
        {
            return Ok(_repositoryCore.GetHomeDocuments(id));
        }

        [HttpGet(ApiRoutes.Posts.GetMail)]
        public async Task<IActionResult> GetMail ( [FromQuery] int id )
        {
            
            return Ok(_repositoryCore.GetMail(id));
        }

        [HttpGet(ApiRoutes.Posts.GetChart)]
        public async Task<IActionResult> GetChart ( [FromRoute] int id )
        {

            return Ok(_repositoryCore.GetChart(id));
        }

        [HttpGet(ApiRoutes.Posts.GetPatientId)]
        public async Task<IActionResult> GetPatientId ( [FromRoute] string hin )
        {

            return Ok(_repositoryCore.GetPatientId(hin));
        }


        [HttpGet(ApiRoutes.Posts.GetHomeTree)]
        public async Task<IActionResult> GetHomeTree ( )
        {
            
            List<TreeNode> treeNodes = new List<TreeNode>();

            for(int i = 0; i < 5; i++)
            {
                List<Node> nodes = new List<Node>();
                TreeNode treeNode = new TreeNode(); 
                for (int j = 0; j< 5; j++)
                {
                    Node node = new Node();
                    node .text = "Child"+j.ToString();
                    node.id = j.ToString();
                    node.icon = "";
                    node.href = "";
                    node.onclick = "loadItem(" + i * j + ")";

                    nodes.Add(node);

                }

                treeNode.text = "parent"+ i.ToString();
                treeNode.nodes = nodes;

                treeNodes.Add(treeNode);
            } 
            
            return Ok(treeNodes);
        }

        //UpdateDemographic




    }
}
