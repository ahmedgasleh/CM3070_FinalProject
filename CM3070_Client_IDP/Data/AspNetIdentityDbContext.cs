using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CM3070_Client_IDP.Data
{
	public class AspNetIdentityDbContext : IdentityDbContext
	{
		public AspNetIdentityDbContext(DbContextOptions<AspNetIdentityDbContext> options)
		  : base(options)
		{
		}
	}
}
